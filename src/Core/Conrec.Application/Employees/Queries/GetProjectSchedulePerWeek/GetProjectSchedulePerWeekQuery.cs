using MediatR;

namespace Conrec.Application.Employees.Queries.GetProjectSchedulePerWeek
{
    public class GetProjectSchedulePerWeekQuery : IRequest<ProjectSchedulePerWeekModel>
    {
        public int Id { get; set; }
    }
}
