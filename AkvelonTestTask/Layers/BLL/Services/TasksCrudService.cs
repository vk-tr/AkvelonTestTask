using System.Collections.Generic;
using System.Threading.Tasks;
using AkvelonTestTask.Layers.DAL.Repositories;
using AkvelonTestTask.Models;

namespace AkvelonTestTask.Layers.BLL.Services
{
    /// <summary>
    /// Task CRUD service.
    /// </summary>
    public class TasksCrudService
    {
        private readonly TaskRepository _taskRepository;

        public TasksCrudService(
            TaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        /// <summary>
        /// Get collection of all Task Entities.
        /// </summary>
        public async Task<IEnumerable<TaskEntity>> GetAllTasks()
        {
            var tasks = await _taskRepository.GetAll();

            return tasks;
        }

        /// <summary>
        /// Get specified Task Entity.
        /// </summary>
        public async Task<TaskEntity> GetTask(long id)
        {
            var task = await _taskRepository.Get(id);

            return task;
        }

        /// <summary>
        /// Update specified Task Entity.
        /// </summary>
        public async Task UpdateTask(long id, TaskEntity taskEntity)
        {
            var taskToUpdate = await _taskRepository.Get(id);

            taskToUpdate.Name = taskEntity.Name;
            taskToUpdate.Description = taskEntity.Description;
            taskToUpdate.Priority = taskEntity.Priority;
            taskToUpdate.TaskStatus = taskEntity.TaskStatus;

            await _taskRepository.Update(taskToUpdate);
        }

        /// <summary>
        /// Create specified Task Entity.
        /// </summary>
        public async Task CreateTask(TaskEntity taskEntity)
        {
            await _taskRepository.Create(taskEntity);
        }

        /// <summary>
        /// Delete specified Task Entity.
        /// </summary>
        public async Task DeleteTask(long id)
        {
            await _taskRepository.Delete(id);
        }
    }
}