using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TaskCore.Models;

namespace TaskCore.Repositories
{
    public class TaskUnitRepository : ITaskUnitRepository
    {
        private readonly MyTaskDbContext dbContext;
        public TaskUnitRepository(MyTaskDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IQueryable<TaskUnit> GetAll()
        {
            return dbContext.TaskUnits;
        }

        public async Task<TaskUnit> GetAsync(int taskUnitID)
        {
            return await dbContext.TaskUnits.FindAsync(taskUnitID);
        }

        public async Task<TaskUnit> CreateAsync(TaskUnit newTaskUnit)
        {
            await dbContext.TaskUnits.AddAsync(newTaskUnit);
            await dbContext.SaveChangesAsync();
            return newTaskUnit;
        }

        public async Task UpdateAsync(TaskUnit taskUnit)
        {
            var target = dbContext.TaskUnits.Single(x => x.TaskUnitId == taskUnit.TaskUnitId);
            target = taskUnit;
            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int taskUnitId)
        {
            dbContext.TaskUnits.Remove(dbContext.TaskUnits.Single(x => x.TaskUnitId == taskUnitId));
            await dbContext.SaveChangesAsync();
        }

        public IQueryable<TaskUnit> Find(Expression<Func<TaskUnit, bool>> predicate)
        {
            return dbContext.TaskUnits.Where(predicate);
        }
    }
}
