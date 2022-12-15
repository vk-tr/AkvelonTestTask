using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AkvelonTestTask.Layers.DAL.Repositories;
using AkvelonTestTask.Models;

namespace AkvelonTestTask.Layers.BLL.Services
{
    /// <summary>
    /// Project CRUD service.
    /// </summary>
    public class ProjectsCrudService
    {
        private readonly ProjectRepository _projectRepository;
        private readonly TaskRepository _taskRepository;

        public ProjectsCrudService(
            ProjectRepository projectRepository,
            TaskRepository taskRepository)
        {
            _projectRepository = projectRepository;
            _taskRepository = taskRepository;
        }

        /// <summary>
        /// Get collection of all Project Entities.
        /// </summary>
        public async Task<IEnumerable<ProjectEntity>> GetAllProjects()
        {
            var projects = await _projectRepository.GetAll();

            return projects;
        }

        /// <summary>
        /// Get specified Project Entity.
        /// </summary>
        public async Task<ProjectEntity> GetProject(long id)
        {
            var project = await _projectRepository.Get(id);

            return project;
        }

        /// <summary>
        /// Update specified Project Entity.
        /// </summary>
        public async Task UpdateProject(long id, ProjectEntity projectEntity)
        {
            var projectToUpdate = await _projectRepository.Get(id);

            projectToUpdate.Name = projectEntity.Name;
            projectToUpdate.Priority = projectEntity.Priority;
            projectToUpdate.CompletionDate = projectEntity.CompletionDate;
            projectToUpdate.ProjectStatus = projectEntity.ProjectStatus;
            projectToUpdate.StartDate = projectEntity.StartDate;

            await _projectRepository.Update(projectToUpdate);
        }

        /// <summary>
        /// Create specified Project Entity.
        /// </summary>
        public async Task CreateProject(ProjectEntity projectEntity)
        {
            await _projectRepository.Create(projectEntity);
        }

        /// <summary>
        /// Delete specified Project Entity.
        /// </summary>
        public async Task DeleteProject(long id)
        {
            await _projectRepository.Delete(id);
        }

        /// <summary>
        /// Get Tasks Entities that correspond to specified Project Entity.
        /// </summary>
        public async Task<IEnumerable<TaskEntity>> GetTasksInProject(long id)
        {
            var tasks = await _taskRepository.GetAll();

            return tasks.Where(x => x.ProjectEntityId == id);
        }
    }
}