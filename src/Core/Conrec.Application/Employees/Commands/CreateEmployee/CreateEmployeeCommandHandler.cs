using Conrec.Application.Models;
using Conrec.Cryptography;
using Conrec.Domain.Entities;
using Conrec.Persistence;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Conrec.Application.Employees.Commands.CreateEmployee
{
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, Unit>
    {
        private readonly ConrecDbContext _context;
        private readonly PasswordManager _passwordManager;
        public CreateEmployeeCommandHandler(ConrecDbContext context, PasswordManager passwordManager)
        {
            _context = context;
            _passwordManager = passwordManager;
        }

        public async Task<Unit> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            if (request.User == null)
            {
                throw new Exception(nameof(User) + " doesn't exist");
            }

            var userModel = request.User;
            userModel.RegisterDate = DateTimeOffset.Now;
            userModel.Password = _passwordManager.EncryptPassword(userModel.Password, CreatePasswordSalt(userModel));

            var userRole = _context.UserRole.Find(1); // user role for employee

            var user = new Domain.Entities.User
            {
                FirstName = userModel.FirstName,
                LastName = userModel.LastName,
                Email = userModel.Email,
                Password = userModel.Password,
                RegisterDate = userModel.RegisterDate,
                Region = new Region
                {
                    Id = userModel.RegionId
                },
                UserRole = userRole
            };

            var employee = new Employee
            {
                User = user,
                NINO = request.NINO,
                Experience = request.Experience,
                AvailabilWorkImmediate = request.AvailabilWorkImmediate,
                AvailabilStartsOn = request.AvailabilStartsOn,
                CountryId = request.CountryId,
                SkillId = request.SkillId
            };

            if (request.AdditionalInformation != null)
            {
                employee.AdditionalInformation = new AdditionalInformation
                {
                    HasOwnCar = request.AdditionalInformation.HasOwnCar,
                    HasRequiredPPE = request.AdditionalInformation.HasRequiredPPE,
                    WillingMiles = request.AdditionalInformation.WillingMiles,
                    Details = request.AdditionalInformation.Details
                };
            }

            // save user
            _context.Employee.Add(employee);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }

        private string CreatePasswordSalt(UserDetailModel user)
        {
            return user.Email.GetHashCode().ToString() + user.RegisterDate.DateTime.ToString();
        }
    }
}
