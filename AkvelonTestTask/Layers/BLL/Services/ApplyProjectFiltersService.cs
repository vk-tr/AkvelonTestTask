using System.Collections.Generic;
using AkvelonTestTask.Models;

namespace AkvelonTestTask.Layers.BLL.Services
{
    /// <summary>
    /// Service for apply filter, sorter and pager to Projects collection.
    /// </summary>
    public class ApplyProjectFiltersService
    {
        private readonly ProjectsSortingService _projectsSortingService;
        private readonly ProjectsFilterService _projectsFilterService;
        private readonly ProjectsPagingService _projectsPagingService;

        public ApplyProjectFiltersService(
            ProjectsSortingService projectsSortingService,
            ProjectsFilterService projectsFilterService,
            ProjectsPagingService projectsPagingService)
        {
            _projectsSortingService = projectsSortingService;
            _projectsFilterService = projectsFilterService;
            _projectsPagingService = projectsPagingService;
        }

        /// <summary>
        /// Applys filter, sorter and pager to Projects collection.
        /// </summary>
        public IEnumerable<ProjectEntity> Apply(
            IEnumerable<ProjectEntity> projectEntities,
            string sortingString,
            string filterString,
            int? limitRange)
        {
            var sorted = _projectsSortingService.Sort(projectEntities, sortingString);

            var filtered = _projectsFilterService.Filter(sorted, filterString);

            var paged = _projectsPagingService.Limit(filtered, limitRange);

            return paged;
        }
    }
}