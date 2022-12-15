using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AkvelonTestTask.Enums;

namespace AkvelonTestTask.Models
{
    [Table("tasks_tbl")]
    public class TaskEntity
    {
        [Column("id")]
        public long Id { get; set; }

        [Column("name")]
        [Required]
        public string Name { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("task_status")]
        public TaskStatus TaskStatus { get; set; }

        [Column("priority")]
        public int Priority { get; set; }

        [Column("project_id")]
        [Required]
        public long ProjectEntityId { get; set; }
    }
}