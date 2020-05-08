using MediatR;

namespace Conrec.Application.Employees.Queries.GetProjectDetails
{
    public class GetProjectDetailsQuery : IRequest<ProjectDetailsModel>
    {
        public int Id { get; set; }
    }
}
