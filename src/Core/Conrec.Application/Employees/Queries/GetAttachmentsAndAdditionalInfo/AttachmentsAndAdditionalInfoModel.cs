using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Conrec.Application.Models;
using Conrec.Domain.Entities;

namespace Conrec.Application.Employees.Queries.GetAttachmentsAndAdditionalInfo
{
    public class AttachmentsAndAdditionalInfoModel
    {
        public int WillingMiles { get; set; }
        public string Details { get; set; }
        public bool HasOwnCar { get; set; }
        public bool HasRequiredPPE { get; set; }
        public ICollection<DocumentModel> Attachments { get; set; }

        public static Expression<Func<Employee, AttachmentsAndAdditionalInfoModel>> Projection
        {
            get
            {
                return employee => new AttachmentsAndAdditionalInfoModel
                {
                    WillingMiles = employee.AdditionalInformation.WillingMiles,
                    Details = employee.AdditionalInformation.Details,
                    HasOwnCar = employee.AdditionalInformation.HasOwnCar,
                    HasRequiredPPE = employee.AdditionalInformation.HasRequiredPPE,
                    Attachments = employee.Documents.Select(x => new DocumentModel
                    {
                       Name = x.Name,
                       CreateDate = x.CreateDate,
                       Path = x.Path
                    }).ToList()
                };
            }
        }

        public static AttachmentsAndAdditionalInfoModel Create(Employee employee)
        {
            return Projection.Compile().Invoke(employee);
        }
    }
}
