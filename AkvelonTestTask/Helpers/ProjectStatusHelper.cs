using AkvelonTestTask.Enums;
using AkvelonTestTask.Exceptions;

namespace AkvelonTestTask.Helpers
{
    /// <summary>
    /// Helper for parsing int status value to ProjectStatus value.
    /// </summary>
    public static class ProjectStatusHelper
    {
        /// <summary>
        /// Parse int value to ProjectStatus value.
        /// </summary>
        public static ProjectStatus Parse(int status)
        {
            switch (status)
            {
                case 0:
                    return ProjectStatus.NotStarted;
                case 1:
                    return ProjectStatus.Active;
                case 2:
                    return ProjectStatus.Completed;
                default:
                    throw new ValidationException("Incorrect argument for project status.");
            }
        }
    }
}