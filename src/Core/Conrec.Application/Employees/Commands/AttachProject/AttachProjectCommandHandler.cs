using Conrec.Application.Models;
using Conrec.Domain.Entities;
using Conrec.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Conrec.Application.Employees.Commands.AttachProject
{
    public class AttachProjectCommandHandler : IRequestHandler<AttachProjectCommand, Unit>
    {
        private readonly ConrecDbContext _context;

        public AttachProjectCommandHandler(ConrecDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(AttachProjectCommand request, CancellationToken cancellationToken)
        {
            var employee = await _context.Employee.FindAsync(request.EmployeeId);

            if (employee == null)
            {
                throw new Exception(nameof(Employer) + request.EmployeeId);
            }

            var project = await _context.Project.FindAsync(request.ProjectId);

            if (project == null)
            {
                throw new Exception(nameof(Project) + request.EmployeeId + " doesn't exit");
            }

            if (employee.ProjectEmployees.Any(x => x.ProjectId == project.Id))
            {
                throw new Exception(nameof(ProjectEmployee) + request.EmployeeId + " already have attached project " + project.Id);
            }

            var projectEmployee = new ProjectEmployee
            {
                EmployeeId = employee.Id,
                ProjectId = project.Id,
                IsActive = request.IsActive,
                TotalTimeWork = request.TotalTimeWork
            };

            projectEmployee.ProjectSchedules = project.ProjectSchedules;

            // attach project to emploee
            _context.ProjectEmployee.Add(projectEmployee);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
