using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TaskCore.Models;

namespace TaskCore.Repositories
{
    public interface IUserRepository
    {
        IQueryable<User> GetAll();
        Task<User> CreateAsync(User newUser);
        IQueryable<User> Find(Expression<Func<User, bool>> predicate);
    }
}
