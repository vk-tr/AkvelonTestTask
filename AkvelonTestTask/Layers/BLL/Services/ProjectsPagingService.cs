using System.Collections.Generic;
using AkvelonTestTask.Layers.BLL.Extensions;
using AkvelonTestTask.Models;

namespace AkvelonTestTask.Layers.BLL.Services
{
    /// <summary>
    /// Paging service for Project Entities collection.
    /// </summary>
    public class ProjectsPagingService
    {
        /// <summary>
        /// Apply paging for Project Entities collection.
        /// </summary>
        /// <param name="projectEntities">Project Entities collection.</param>
        /// <param name="range">Range value.</param>
        /// <returns></returns>
        public IEnumerable<ProjectEntity> Limit(IEnumerable<ProjectEntity> projectEntities, int? range)
        {
            if (range.HasValue)
            {
                return projectEntities.Limit(range.Value);
            }

            return projectEntities;
        }
    }
}