using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Conrec.Persistence;
using System.Linq;
using Microsoft.EntityFrameworkCore;


namespace Conrec.Application.User.Queries.GetUserValidation
{
    using Conrec.Application.Models;
    using Conrec.Cryptography;
    using Conrec.Domain.Entities;

    public class UserValidatorQueryHandler : IRequestHandler<UserValidatorQuery, UserValidatorModel>
    {
        private readonly ConrecDbContext _context;
        private readonly PasswordManager _passwordManager;

        public UserValidatorQueryHandler(ConrecDbContext context, PasswordManager passwordManager)
        {
            _context = context;
            _passwordManager = passwordManager;
        }

        public async Task<UserValidatorModel> Handle(UserValidatorQuery request, CancellationToken cancellationToken)
        {

            var user = await _context.User
                .Where(x => x.Email == request.Email)
                .FirstOrDefaultAsync();

            var salt = CreatePasswordSalt(user);

            if (user == null || !_passwordManager.VerifyPassword(request.Password, user.Password, salt))
            {
                throw new Exception("Invalid email or password");
            }
       
            return UserValidatorModel.Create(user);
        }

        private string CreatePasswordSalt(User user)
        {
            return user.Id.ToString() + user.RegisterDate.Value.DateTime.ToString();
        }
    }
}
