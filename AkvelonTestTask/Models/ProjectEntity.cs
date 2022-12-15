using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AkvelonTestTask.Enums;

namespace AkvelonTestTask.Models
{
    [Table("projects_tbl")]
    public class ProjectEntity
    {
        [Column("id")]
        public long Id { get; set; }

        [Column("name")]
        [Required]
        public string Name { get; set; }

        [Column("start_date")]
        public DateTime StartDate { get; set; }

        [Column("completion_date")]
        public DateTime CompletionDate { get; set; }

        [Column("project_status")]
        public ProjectStatus ProjectStatus { get; set; }

        [Column("priority")]
        public int Priority { get; set; }
    }
}