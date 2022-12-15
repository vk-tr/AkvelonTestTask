using System;
using System.Collections.Generic;
using AkvelonTestTask.Helpers;
using AkvelonTestTask.Layers.BLL.Extensions;
using AkvelonTestTask.Models;

namespace AkvelonTestTask.Layers.BLL.Services
{
    /// <summary>
    /// Filter service for Project Entities collection.
    /// </summary>
    public class ProjectsFilterService
    {
        /// <summary>
        /// Apply filter for Project Entities collection.
        /// </summary>
        /// <param name="projects">Project Entities collection.</param>
        /// <param name="filterString">String with filter expressions.</param>
        /// <remarks>
        /// Notice, that you can add multiple filter expressions due to '+' operator
        /// </remarks>
        public IEnumerable<ProjectEntity> Filter(
            IEnumerable<ProjectEntity> projects,
            string filterString)
        {
            if (string.IsNullOrEmpty(filterString))
            {
                return projects;
            }

            var filterConditions = filterString.Split('+');

            foreach (var filterCondition in filterConditions)
            {
                var condVal = filterCondition.Split('_');

                var condition = condVal[0];
                var value = condVal[1];

                switch (condition)
                {
                    case "priority":
                    {
                        var filtVal = Int32.Parse(value);
                        projects = projects.FilterByPriority(filtVal);
                        break;
                    }
                    case "status":
                    {
                        var intVal = Int32.Parse(value);
                        var filtVal = ProjectStatusHelper.Parse(intVal);
                        projects = projects.FilterByStatus(filtVal);
                        break;
                    }
                    case "startAt":
                    {
                        var filtVal = DateTime.Parse(value);
                        projects = projects.FilterStartAt(filtVal);
                        break;
                    }
                }
            }

            return projects;
        }
    }
}