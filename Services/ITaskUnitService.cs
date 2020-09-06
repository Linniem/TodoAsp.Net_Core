using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TaskCore.Models;
using TaskCore.ViewModels;

namespace TaskCore.Services
{
    public interface ITaskUnitService
    {
        Task AddTaskAsync(int userId, string taskName);
        Task<bool> DeleteOneTaskUnitAsync(int taskId, int userId);
        Task<IEnumerable<TaskUnitViewModel>> GetUserAllTasks(int userId);
        Task<bool> UpdateOneFieldAsync(Expression<Func<TaskUnit, bool>> findPredicate, Action<TaskUnit> updateMethod);
        Task<bool> UpdateTaskUnitAsync(TaskUnitViewModel taskUnitVM);
    }
}