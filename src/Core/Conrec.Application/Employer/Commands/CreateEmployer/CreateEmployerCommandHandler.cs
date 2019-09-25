using Conrec.Persistence;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Conrec.Application.Employees.Commands.CreateEmployer
{
    using Conrec.Application.Models;
    using Conrec.Cryptography;
    using Conrec.Domain.Entities;
    using Conrec.Helper;
    using System.Linq;

    public class CreateEmployerCommandHandler : IRequestHandler<CreateEmployerCommand, int>
    {
        private readonly ConrecDbContext _context;
        private readonly PasswordManager _passwordManager;

        public CreateEmployerCommandHandler(ConrecDbContext context, PasswordManager passwordManager)
        {
            _context = context;
            _passwordManager = passwordManager;
        }


        public async Task<int> Handle(CreateEmployerCommand request, CancellationToken cancellationToken)
        {
            var employerModel = request.Employer;
            employerModel.RegisterDate = DateTimeOffset.Now;
            employerModel.Password = _passwordManager.EncryptPassword(request.Employer.Password, CreatePasswordSalt(employerModel));


            var userRole = _context.UserRole.Find(2); // user role for employer

            var company = new Company
            {
                Name = request.Company?.Name,
                Reference = request.Company.Reference
            };

            var employer = new Employer
            {
                User = new User {
                     FirstName = employerModel.FirstName,
                     LastName = employerModel.LastName,
                     Email = employerModel.Email,
                     Password = employerModel.Password,
                     RegisterDate = employerModel.RegisterDate,
                     Region = new Region {
                         Name = employerModel.Region?.Name,
                         PostCode = employerModel.Region?.PostCode
                     },
                     UserRole = userRole
                },
                Company = company,
                JobRoleId = request.JobRoleId
            };

            AttachRegion(employer.User, request, cancellationToken);

            _context.Employer.Add(employer);

            await _context.SaveChangesAsync(cancellationToken);

            return employer.Id;
        }


        private void AttachRegion(User user, CreateEmployerCommand request, CancellationToken cancellationToken)
        {
            var regionRequestPostCode = request.Employer.Region?.PostCode;
            var searchRegionResponse = SerachRegion(regionRequestPostCode);
            var regionName = searchRegionResponse.addresses[0]
                        .Split(',')
                        .Where(x => !string.IsNullOrWhiteSpace(x))
                        .LastOrDefault();

            if (string.IsNullOrWhiteSpace(regionName))
            {
                throw new Exception(nameof(Region) + " region doesn't found");
            }

            var region = _context.Region.Where(r => r.Name == regionName).FirstOrDefault();
            
            // attach existed region
            if (region != null && region.PostCode == regionRequestPostCode)
            {
                user.Region = region;
            }

            if (region == null || region.PostCode != regionRequestPostCode)
            {
                // create new region
                user.Region = new Region
                {
                  Name = regionName,
                  PostCode = regionRequestPostCode
                };
            }
        }

        private RegionModelResponse SerachRegion(string postCode)
        {
            var apiKey = "yYToZyWyB0yPze2OekdB_g20819";
            var baseWebApiUrl = $"https://api.getaddress.io/find/{postCode}?api-key={apiKey}";

            return WebApiClientHelper.CallWebApiMethod<RegionModelResponse>(baseWebApiUrl);
        }

        private string CreatePasswordSalt(CreateEmployerModel user)
        {
            return user.Email.GetHashCode().ToString() + user.RegisterDate.Value.DateTime.ToString();
        }
    }
}
