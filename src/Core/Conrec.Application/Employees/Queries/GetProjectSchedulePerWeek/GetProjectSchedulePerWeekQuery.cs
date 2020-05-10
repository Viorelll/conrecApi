using MediatR;
using System.Collections.Generic;

namespace Conrec.Application.Employees.Queries.GetProjectSchedulePerWeek
{
    public class GetProjectSchedulePerWeekQuery : IRequest<List<ProjectSchedulePerWeekModel>>
    {
        public int Id { get; set; }
    }
}
