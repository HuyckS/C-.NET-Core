using System;
using System.ComponentModel.DataAnnotations;
namespace UserDashboard.Models
{
    public class Tasker
    {
        [Key]
        public int TaskerId { get; set; }

        [Display(Name = "Complete")]
        public bool TaskerComplete { get; set; }

        [DataType(DataType.Date)]
        [Required]
        [Display(Name = "Due Date")]
        public DateTime TaskerDueDate { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string TaskerDescription { get; set; }


        //Project Connection
        [Display(Name = "Project")]
        public int ProjectId { get; set; }
        public Project ProjectOfTasker { get; set; }

        //User Connection
        [Display(Name = "Assigned to")]
        public string UserOfTasker { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}