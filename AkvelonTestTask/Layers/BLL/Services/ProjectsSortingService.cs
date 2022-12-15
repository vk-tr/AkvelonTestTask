using System;
using System.Collections.Generic;
using System.Linq;
using AkvelonTestTask.Layers.BLL.Extensions;
using AkvelonTestTask.Models;

namespace AkvelonTestTask.Layers.BLL.Services
{
    /// <summary>
    /// Sorting service for Project Entities collection.
    /// </summary>
    public class ProjectsSortingService
    {
        /// <summary>
        /// Apply sorting for Project Entities collection.
        /// </summary>
        /// <param name="projects">Project Entities collection.</param>
        /// <param name="sortString">String with sorting expression.</param>
        /// <returns></returns>
        public IEnumerable<ProjectEntity> Sort(IEnumerable<ProjectEntity> projects, string sortString)
        {
            switch (sortString)
            {
                case "priority_asc":
                    return projects.SortByPriority();
                case "priority_desc":
                    return projects.SortByPriorityDesc();
                case "status_asc":
                    return projects.SortByStatus();
                case "status_desc":
                    return projects.SortByStatusDesc();
                case "start_date_asc":
                    return projects.SortByStartDate();
                case "start_date_desc":
                    return projects.SortByStartDateDesc();
                default:
                    return projects.OrderBy(x => x.Id);
            }
        }
    }
}