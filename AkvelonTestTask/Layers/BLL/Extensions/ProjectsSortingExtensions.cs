using System;
using System.Collections.Generic;
using System.Linq;
using AkvelonTestTask.Models;

namespace AkvelonTestTask.Layers.BLL.Extensions
{
    public static class ProjectsSortingExtensions
    {
        public static IEnumerable<ProjectEntity> SortByPriority(
            this IEnumerable<ProjectEntity> projectEntities)
        {
            return projectEntities
                .OrderBy(x => x.Priority);
        }

        public static IEnumerable<ProjectEntity> SortByPriorityDesc(
            this IEnumerable<ProjectEntity> projectEntities)
        {
            return projectEntities
                .OrderByDescending(x => x.Priority);
        }

        public static IEnumerable<ProjectEntity> SortByStatus(
            this IEnumerable<ProjectEntity> projectEntities)
        {
            return projectEntities
                .OrderBy(x => x.ProjectStatus);
        }

        public static IEnumerable<ProjectEntity> SortByStatusDesc(
            this IEnumerable<ProjectEntity> projectEntities)
        {
            return projectEntities
                .OrderByDescending(x => x.ProjectStatus);
        }

        public static IEnumerable<ProjectEntity> SortByStartDate(
            this IEnumerable<ProjectEntity> projectEntities)
        {
            return projectEntities
                .OrderBy(x => x.StartDate);
        }

        public static IEnumerable<ProjectEntity> SortByStartDateDesc(
            this IEnumerable<ProjectEntity> projectEntities)
        {
            return projectEntities
                .OrderByDescending(x => x.StartDate);
        }
    }
}