using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TaskCore.Models;

namespace TaskCore.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly MyTaskDbContext dbContext;
        public UserRepository(MyTaskDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IQueryable<User> GetAll()
        {
            return dbContext.Users;
        }

        public IQueryable<User> Find(Expression<Func<User, bool>> predicate)
        {
            return dbContext.Users.Where(predicate);
        }

        public async Task<User> CreateAsync(User newUser)
        {
            await dbContext.Users.AddAsync(newUser);
            await dbContext.SaveChangesAsync();
            return newUser;
        }
    }
}
