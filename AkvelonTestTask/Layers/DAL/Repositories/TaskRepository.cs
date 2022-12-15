using System.Collections.Generic;
using System.Threading.Tasks;
using AkvelonTestTask.Layers.DAL.DbContexts;
using AkvelonTestTask.Layers.DAL.Interfaces;
using AkvelonTestTask.Models;
using Microsoft.EntityFrameworkCore;

namespace AkvelonTestTask.Layers.DAL.Repositories
{
    /// <summary>
    /// Repository interface realization for Task Entity.
    /// </summary>
    public class TaskRepository : IRepository<TaskEntity>
    {
        private readonly ProjectDbContext _projectDbContext;

        public TaskRepository(
            ProjectDbContext projectDbContext)
        {
            _projectDbContext = projectDbContext;
        }

        public async Task<IEnumerable<TaskEntity>> GetAll()
        {
            return await _projectDbContext.TaskEntities.ToListAsync();
        }

        public async Task<TaskEntity> Get(long id)
        {
            return await _projectDbContext.TaskEntities.FindAsync(id);
        }

        public async Task Create(TaskEntity item)
        {
            await _projectDbContext.TaskEntities.AddAsync(item);
            await _projectDbContext.SaveChangesAsync();
        }

        public async Task Update(TaskEntity item)
        {
            _projectDbContext.TaskEntities.Update(item);
            await _projectDbContext.SaveChangesAsync();
        }

        public async Task Delete(long id)
        {
            var itemToDelete = await Get(id);

            if (itemToDelete == null)
            {
                return;
            }

            _projectDbContext.TaskEntities.Remove(itemToDelete);
            await _projectDbContext.SaveChangesAsync();
        }
    }
}