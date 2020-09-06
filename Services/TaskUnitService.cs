using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TaskCore.Models;
using TaskCore.Repositories;
using TaskCore.ViewModels;

namespace TaskCore.Services
{
    public class TaskUnitService : ITaskUnitService
    {
        private readonly ITaskUnitRepository taskUnitRepo;
        public TaskUnitService(ITaskUnitRepository taskUnitRepo)
        {
            this.taskUnitRepo = taskUnitRepo;
        }

        public async Task AddTaskAsync(int userId, string taskName)
        {
            await taskUnitRepo.CreateAsync(new TaskUnit()
            {
                IsComplete = false,
                IsImportant = false,
                TaskName = taskName,
                UserId = userId,
                Steps = string.Empty,
                UserMemoText = string.Empty
            });
        }

        public async Task<IEnumerable<TaskUnitViewModel>> GetUserAllTasks(int userId)
        {
            var allTaskUnits = await taskUnitRepo.GetAll()
                .Where(x => x.UserId == userId)
                .ToListAsync();
            var result = new List<TaskUnitViewModel>();
            foreach (var taskUnit in allTaskUnits)
            {
                result.Add(new TaskUnitViewModel()
                {
                    // If field is a lot => AutoMapper
                    Steps = taskUnit.Steps,
                    TaskName = taskUnit.TaskName,
                    TaskUnitId = taskUnit.TaskUnitId,
                    UserMemoText = taskUnit.UserMemoText,
                    UserId = taskUnit.UserId,
                    IsComplete = taskUnit.IsComplete,
                    IsImportant = taskUnit.IsImportant
                });
            }
            return result;
        }

        public async Task<bool> UpdateTaskUnitAsync(TaskUnitViewModel taskUnitVM)
        {
            var targetTaskUnit = await taskUnitRepo
                .Find(x => x.TaskUnitId == taskUnitVM.TaskUnitId && x.UserId == taskUnitVM.UserId)
                .FirstOrDefaultAsync();
            if (targetTaskUnit != null)
            {
                targetTaskUnit.TaskUnitId = (int)taskUnitVM.TaskUnitId;
                targetTaskUnit.TaskName = taskUnitVM.TaskName;
                targetTaskUnit.Steps = taskUnitVM.Steps;
                targetTaskUnit.UserMemoText = taskUnitVM.UserMemoText;
                targetTaskUnit.IsComplete = taskUnitVM.IsComplete;
                targetTaskUnit.IsImportant = taskUnitVM.IsImportant;
                await taskUnitRepo.UpdateAsync(targetTaskUnit);
                return true;
            }

            return false;
        }

        public async Task<bool> DeleteOneTaskUnitAsync(int taskId, int userId)
        {
            var targetTaskUnit = taskUnitRepo
                .Find(x => x.TaskUnitId == taskId && x.UserId == userId);
            if (targetTaskUnit != null)
            {
                await taskUnitRepo.DeleteAsync(taskId);
                return true;
            }
            return false;
        }

        public async Task<bool> UpdateOneFieldAsync(Expression<Func<TaskUnit, bool>> findPredicate, Action<TaskUnit> updateMethod)
        {
            var targetTaskUnit = await taskUnitRepo
                .Find(findPredicate)
                .FirstOrDefaultAsync();
            if (targetTaskUnit != null)
            {
                updateMethod.Invoke(targetTaskUnit);
                await taskUnitRepo.UpdateAsync(targetTaskUnit);
                return true;
            }
            return false;
        }

        //public async Task<bool> SetImportanceAsync(int taskId, bool isImportant, int userId)
        //{
        //    var targetTaskUnit = taskUnitRepo
        //        .Find(x => x.TaskUnitId == taskId && x.UserId == userId)
        //        .FirstOrDefault();
        //    if (targetTaskUnit != null)
        //    {
        //        targetTaskUnit.IsImportant = isImportant;
        //        await taskUnitRepo.UpdateAsync(targetTaskUnit);
        //        return true;
        //    }
        //    return false;
        //}

        //public async Task SetCompleteOrNotAsync(int taskId, bool isComplete)
        //{
        //    var targetTaskUnit = await taskUnitRepo.GetAsync(taskId);
        //    targetTaskUnit.IsComplete = isComplete;
        //    await taskUnitRepo.UpdateAsync(targetTaskUnit);
        //}
    }
}
