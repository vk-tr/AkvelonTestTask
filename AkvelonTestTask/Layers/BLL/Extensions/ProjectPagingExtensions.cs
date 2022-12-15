using System.Collections.Generic;
using System.Linq;
using AkvelonTestTask.Models;

namespace AkvelonTestTask.Layers.BLL.Extensions
{
    public static class ProjectPagingExtensions
    {
        public static IEnumerable<ProjectEntity> Limit(
            this IEnumerable<ProjectEntity> projectEntities, int range)
        {
            return projectEntities
                .Take(range);
        }
    }
}