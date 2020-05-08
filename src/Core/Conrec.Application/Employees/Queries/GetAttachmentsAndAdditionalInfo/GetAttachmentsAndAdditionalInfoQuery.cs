using MediatR;

namespace Conrec.Application.Employees.Queries.GetAttachmentsAndAdditionalInfo
{
    public class GetAttachmentsAndAdditionalInfoQuery : IRequest<AttachmentsAndAdditionalInfoModel>
    {
        public int Id { get; set; }
    }
}
