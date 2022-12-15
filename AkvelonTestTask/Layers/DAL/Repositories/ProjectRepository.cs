using System.Collections.Generic;
using System.Threading.Tasks;
using AkvelonTestTask.Layers.DAL.DbContexts;
using AkvelonTestTask.Layers.DAL.Interfaces;
using AkvelonTestTask.Models;
using Microsoft.EntityFrameworkCore;

namespace AkvelonTestTask.Layers.DAL.Repositories
{
    /// <summary>
    /// Repository interface realization for Project Entity.
    /// </summary>
    public class ProjectRepository : IRepository<ProjectEntity>
    {
        private readonly ProjectDbContext _projectDbContext;

        public ProjectRepository(
            ProjectDbContext projectDbContext)
        {
            _projectDbContext = projectDbContext;
        }

        public async Task<IEnumerable<ProjectEntity>> GetAll()
        {
            return await _projectDbContext.ProjectEntities.ToListAsync();
        }

        public async Task<ProjectEntity> Get(long id)
        {
            return await _projectDbContext.ProjectEntities.FindAsync(id);
        }

        public async Task Create(ProjectEntity item)
        {
            await _projectDbContext.ProjectEntities.AddAsync(item);
            await _projectDbContext.SaveChangesAsync();
        }

        public async Task Update(ProjectEntity item)
        {
            _projectDbContext.ProjectEntities.Update(item);
            await _projectDbContext.SaveChangesAsync();
        }

        public async Task Delete(long id)
        {
            var itemToDelete = await Get(id);

            if (itemToDelete == null)
            {
                return;
            }

            _projectDbContext.ProjectEntities.Remove(itemToDelete);
            await _projectDbContext.SaveChangesAsync();
        }
    }
}