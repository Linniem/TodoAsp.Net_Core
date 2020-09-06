using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TaskCore.Models;

namespace TaskCore.Repositories
{
    public interface ITaskUnitRepository
    {
        Task<TaskUnit> CreateAsync(TaskUnit newTaskUnit);
        Task DeleteAsync(int taskUnitId);
        IQueryable<TaskUnit> Find(Expression<Func<TaskUnit, bool>> predicate);
        IQueryable<TaskUnit> GetAll();
        Task<TaskUnit> GetAsync(int taskUnitID);
        Task UpdateAsync(TaskUnit taskUnit);
    }
}