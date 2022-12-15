using System.Collections.Generic;
using System.Threading.Tasks;

namespace AkvelonTestTask.Layers.DAL.Interfaces
{
    /// <summary>
    /// Repository pattern realization.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T>
    {
        /// <summary>
        /// Get all entities from database.
        /// </summary>
        Task<IEnumerable<T>> GetAll();

        /// <summary>
        /// Get entity from database by id.
        /// </summary>
        Task<T> Get(long id);

        /// <summary>
        /// Create new entity in database.
        /// </summary>
        Task Create(T item);

        /// <summary>
        /// Update existing entity in database.
        /// </summary>
        Task Update(T item);

        /// <summary>
        /// Delete existing entity from database.
        /// </summary>
        Task Delete(long id);
    }
}