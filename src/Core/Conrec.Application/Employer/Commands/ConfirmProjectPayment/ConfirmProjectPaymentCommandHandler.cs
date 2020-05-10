using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Conrec.Application.Employees.Queries.GetProjectSchedulePerWeek;
using Conrec.Domain.Entities;
using Conrec.Persistence;
using MediatR;

namespace Conrec.Application.Employer.Commands.ConfirmProjectPayment
{
    public class ConfirmProjectPaymentCommandHandler : IRequestHandler<ConfirmProjectPaymentCommand, Unit>
    {
        private readonly ConrecDbContext _context;

        public ConfirmProjectPaymentCommandHandler(ConrecDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(ConfirmProjectPaymentCommand request, CancellationToken cancellationToken)
        {
            var projectEmployees = _context.ProjectEmployee.Where(x => x.ProjectId == request.ProjectId).ToList();

            if (!request.HasConfirmAll)
            {
                AdjustProjectEmployeePayment(projectEmployees, request);
            }

            CalculateProjectEmployeePayment(projectEmployees);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }

        private void CalculateProjectEmployeePayment(List<ProjectEmployee> projectEmployees)
        {
            foreach (var projectEmployee in projectEmployees)
            {
                var projectSchedulePerWeek = ProjectSchedulePerWeekModel.Create(projectEmployee);
                var projectEmployeeWorkedHours = CalculateProjectEmployeeWorkedHours(projectSchedulePerWeek);

                var payment = new Payment
                {
                    //AccountNumber = 
                    //ShortCode = 
                    //Subject = 
                    Amount = projectEmployeeWorkedHours * 12,
                    OriginalPayRate = projectEmployeeWorkedHours,
                    CoefficientPayRate = 0.1,
                    AdjustedPayRate = projectEmployeeWorkedHours * 12 * (1 - 0.1),
                    WorkedHours = projectEmployeeWorkedHours,
                    PaymentDate = DateTimeOffset.Now,
                    //CurrencyId = 
                    //PaymentFrequencyId = 
                    //PaymentTypeId = 
                };

                var projectPayment = new ProjectPayment
                {
                    ProjectId = projectEmployee.ProjectId,
                    Payment = payment
                };

                projectEmployee.Project.ProjectPayments.Add(projectPayment);

                projectEmployee.Employee.ProjectPaymentEmployees.Add(new ProjectPaymentEmployee 
                { 
                    EmployeeId = projectEmployee.EmployeeId,
                    ProjectPayment = projectPayment
                });
            }
            
        }

        private int CalculateProjectEmployeeWorkedHours(List<ProjectSchedulePerWeekModel> projectSchedulesPerWeek)
        {
            var totalHours = 0;
            foreach (var projectSchedue in projectSchedulesPerWeek)
            {
                var hoursPerDay = projectSchedue.DayEnd.Hour - projectSchedue.DayStart.Hour;
                var breakPerDay = projectSchedue.BreakEnd.Hour - projectSchedue.BreakStart.Hour;

                if (projectSchedue.IsBreakPaid)
                {
                    totalHours += (hoursPerDay + breakPerDay);
                } else
                {
                    totalHours += (hoursPerDay - breakPerDay);
                }
            }

            return totalHours;
        }

        private void AdjustProjectEmployeePayment(List<ProjectEmployee> projectEmployees, ConfirmProjectPaymentCommand request)
        {
            foreach (var projectEmployee in projectEmployees)
            {
                var projectEmployeesModifiedSchedule = request.ModifiedEmployees.Where(x => x.EmployeeId == projectEmployee.EmployeeId).FirstOrDefault();

                if (projectEmployeesModifiedSchedule != null)
                {
                    var defaultProjectEmployeeSchedules = _context.ProjectSchedule.Where(x => x.ProjectId == projectEmployee.ProjectId)
                       .Select(x => x.Schedule)
                       .ToList();
                    var customProjectEmployeeSchedules = _context.ProjectEmployeeSchedule.Where(x => x.ProjectEmployeeId == projectEmployee.Id)
                      .Select(x => x.Schedule)
                      .ToList();

                    var allProjectEmployeeSchedule = defaultProjectEmployeeSchedules.Union(customProjectEmployeeSchedules);

                    foreach (var employeeSchedule in allProjectEmployeeSchedule)
                    {
                        var newDate = projectEmployeesModifiedSchedule.Dates
                            .FirstOrDefault(y => y.Date.DateTime == employeeSchedule.DayStart.DateTime);

                        employeeSchedule.DayStart = ProjectSchedulePerWeekModel.CleanHours(employeeSchedule.DayStart).AddHours(newDate.DayStart);
                        employeeSchedule.DayEnd = ProjectSchedulePerWeekModel.CleanHours(employeeSchedule.DayEnd).AddHours(newDate.DayEnd);
                    }
                }
            }
        }
    }
}
