using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AkvelonTestTask.Layers.BLL.Services;
using AkvelonTestTask.Models;
using Microsoft.AspNetCore.Mvc;

namespace AkvelonTestTask.Layers.BLL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase

    {
        private readonly ProjectsCrudService _projectsCrudService;
        private readonly ApplyProjectFiltersService _applyProjectFiltersService;

        public ProjectsController(
            ProjectsCrudService projectsCrudService,
            ApplyProjectFiltersService applyProjectFiltersService)
        {
            _projectsCrudService = projectsCrudService;
            _applyProjectFiltersService = applyProjectFiltersService;
        }

        [HttpPost("GetAllProjects")]
        public async Task<ActionResult<IEnumerable<ProjectEntity>>> GetAllProjects(
            string sortString,
            string filterString,
            int? limitRange)
        {
            var projects = await _projectsCrudService.GetAllProjects();

            projects = _applyProjectFiltersService.Apply(
                projects,
                sortString,
                filterString,
                limitRange);

            return new ActionResult<IEnumerable<ProjectEntity>>(projects);
        }

        [HttpGet("GetTasksInProject")]
        public async Task<ActionResult<IEnumerable<TaskEntity>>> GetTasksInProject(long id)
        {
            var tasks = await _projectsCrudService.GetTasksInProject(id);

            return new ActionResult<IEnumerable<TaskEntity>>(tasks);
        }

        [HttpGet("GetProject")]
        public async Task<ActionResult<ProjectEntity>> GetProject(long id)
        {
            var project = await _projectsCrudService.GetProject(id);

            return project;
        }

        [HttpPut("UpdateProject")]
        public async Task<IActionResult> UpdateProject(long id, ProjectEntity projectEntity)
        {
            await _projectsCrudService.UpdateProject(id, projectEntity);

            return Ok();
        }

        [HttpPost("CreateProject")]
        public async Task<ActionResult> CreateProject(ProjectEntity projectEntity)
        {
            await _projectsCrudService.CreateProject(projectEntity);

            return Ok();
        }

        [HttpDelete("DeleteProject")]
        public async Task<IActionResult> DeleteProject(long id)
        {
            await _projectsCrudService.DeleteProject(id);

            return Ok();
        }
    }
}