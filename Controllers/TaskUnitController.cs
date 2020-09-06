using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskCore.Models;
using TaskCore.Services;
using TaskCore.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TaskCore.Controllers
{
    [Route("api/task")]
    [Authorize]
    [ApiController]
    public class TaskUnitController : ControllerBase
    {
        private readonly ITaskUnitService taskUnitService;
        private readonly IUserService userService;
        public TaskUnitController(ITaskUnitService taskUnitService, IUserService userService)
        {
            this.taskUnitService = taskUnitService;
            this.userService = userService;
        }

        [HttpPost]
        public async Task<ActionResult<bool>> Post(TaskUnitViewModel newTask)
        {
            var userId = await userService.GetUserIdAsync(User.Identity.Name);
            if (userId != null)
            {
                await taskUnitService.AddTaskAsync((int)userId, newTask.TaskName);
                return Ok();
            }
            return BadRequest();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskUnitViewModel>>> Get()
        {
            var userId = await userService.GetUserIdAsync(User.Identity.Name);
            if (userId != null)
            {
                return Ok(await taskUnitService.GetUserAllTasks((int)userId));
            }
            return BadRequest();
        }

        [HttpPut]
        public async Task<ActionResult> Put(TaskUnitViewModel taskUnitVM)
        {
            if (await taskUnitService.UpdateTaskUnitAsync(taskUnitVM))
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int taskUnitid)
        {
            var userId = await userService.GetUserIdAsync(User.Identity.Name);
            if (userId != null)
            {
                if (await taskUnitService.DeleteOneTaskUnitAsync(taskUnitid, (int)userId))
                {
                    return Ok();
                }
            }
            return BadRequest();
        }

        //----------------------------------------------------
        // GET: api/<TaskUnitController>
        [HttpPut("tttttt")]
        public async Task<bool> PutTest(TaskUnit taskUnit)
        {
            var userId = await userService.GetUserIdAsync(User.Identity.Name);
            var a = await taskUnitService.UpdateOneFieldAsync
                (x => x.TaskUnitId == taskUnit.TaskUnitId && x.UserId == userId, y => y.UserMemoText = "aaaaa");
            return true;
        }

        // GET api/<TaskUnitController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}
    }
}
