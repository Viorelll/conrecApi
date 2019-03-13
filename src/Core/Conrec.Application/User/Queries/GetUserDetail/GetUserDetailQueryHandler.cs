using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Conrec.Domain.Entities;
using Conrec.Persistence;

namespace Conrec.Application.Employees.Queries.GetUserDetail
{
    public class GetUserDetailQueryHandler : IRequestHandler<GetUserDetailQuery, UserDetailModel>
    {
        private readonly ConrecDbContext _context;

        public GetUserDetailQueryHandler(ConrecDbContext context)
        {
            _context = context;
        }

        public async Task<UserDetailModel> Handle(GetUserDetailQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.User
                .FindAsync(request.Id);

            if (entity == null)
            {
                throw new Exception(nameof(Employee) + request.Id);
            }

            return UserDetailModel.Create(entity);
        }
    }
}
