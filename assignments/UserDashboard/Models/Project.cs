using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace UserDashboard.Models
{
    public class Project
    {
        [Key]
        public int ProjectId { get; set; }

        [Required]
        public string Title { get; set; }
        [Required]
        [Display(Name = "Project Description")]
        public string ProjectDescription { get; set; }

        [DataType(DataType.Date)]
        [Required]
        public DateTime ProjectStartDate { get; set; }

        [DataType(DataType.Date)]
        [Required]
        [Display(Name = "Due Date")]
        public DateTime ProjectDueDate { get; set; }

        public int UserId { get; set; }
        public User ProjectLead { get; set; }
        public List<Assignment> AssignedUsers { get; set; }
        public List<Tasker> ProjectTaskers { get; set; }
        public List<Message> ProjectMessages { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}