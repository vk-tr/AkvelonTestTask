using System.Collections.Generic;
using System.Threading.Tasks;
using AkvelonTestTask.Exceptions;
using AkvelonTestTask.Layers.BLL.Services;
using AkvelonTestTask.Models;
using Microsoft.AspNetCore.Mvc;

namespace AkvelonTestTask.Layers.BLL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly TasksCrudService _tasksCrudService;

        public TasksController(TasksCrudService tasksCrudService)
        {
            _tasksCrudService = tasksCrudService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskEntity>>> GetAllTasks()
        {
            var tasks = await _tasksCrudService.GetAllTasks();

            return new ActionResult<IEnumerable<TaskEntity>>(tasks);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TaskEntity>> GetTask(long id)
        {
            var task = await _tasksCrudService.GetTask(id);

            return task;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask(long id, TaskEntity taskEntity)
        {
            await _tasksCrudService.UpdateTask(id, taskEntity);

            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult> CreateTask(TaskEntity taskEntity)
        {
            await _tasksCrudService.CreateTask(taskEntity);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(long id)
        {
            await _tasksCrudService.DeleteTask(id);

            return Ok();
        }
    }
}