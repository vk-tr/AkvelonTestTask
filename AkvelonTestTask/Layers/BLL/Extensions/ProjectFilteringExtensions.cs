using System;
using System.Collections.Generic;
using System.Linq;
using AkvelonTestTask.Enums;
using AkvelonTestTask.Models;

namespace AkvelonTestTask.Layers.BLL.Extensions
{
    public static class ProjectFilteringExtensions
    {
        public static IEnumerable<ProjectEntity> FilterByPriority(
            this IEnumerable<ProjectEntity> projectEntities, int priority)
        {
            return projectEntities
                .Where(x => x.Priority == priority);
        }

        public static IEnumerable<ProjectEntity> FilterByStatus(
            this IEnumerable<ProjectEntity> projectEntities, ProjectStatus projectStatus)
        {
            return projectEntities
                .Where(x => x.ProjectStatus == projectStatus);
        }

        public static IEnumerable<ProjectEntity> FilterStartAt(
            this IEnumerable<ProjectEntity> projectEntities, DateTime dateTime)
        {
            return projectEntities
                .Where(x => x.StartDate.Date == dateTime.Date);
        }
    }
}