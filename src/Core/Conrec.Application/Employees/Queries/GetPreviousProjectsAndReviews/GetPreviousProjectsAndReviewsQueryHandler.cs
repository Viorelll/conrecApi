using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Conrec.Domain.Entities;
using Conrec.Persistence;
using System.Linq;
using System.Collections.Generic;

namespace Conrec.Application.Employees.Queries.GetPreviousProjectsAndReviews
{
    public class GetPreviousProjectsAndReviewsQueryHandler : IRequestHandler<GetPreviousProjectsAndReviewsQuery, List<PreviousProjectsAndReviewsModel>>
    {
        private readonly ConrecDbContext _context;

        public GetPreviousProjectsAndReviewsQueryHandler(ConrecDbContext context)
        {
            _context = context;
        }

        public async Task<List<PreviousProjectsAndReviewsModel>> Handle(GetPreviousProjectsAndReviewsQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Employee
             .FindAsync(request.Id);

            if (entity == null)
            {
                throw new Exception(nameof(Employee) + request.Id);
            }

            var result = PreviousProjectsAndReviewsModel.Create(entity);

            return result;
        }
    }
}
