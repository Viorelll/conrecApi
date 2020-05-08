using MediatR;
using System.Collections.Generic;

namespace Conrec.Application.Employees.Queries.GetPreviousProjectsAndReviews
{
    public class GetPreviousProjectsAndReviewsQuery : IRequest<List<PreviousProjectsAndReviewsModel>>
    {
        public int Id { get; set; }
    }
}
