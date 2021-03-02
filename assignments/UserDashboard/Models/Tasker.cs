using System;
using System.ComponentModel.DataAnnotations;
namespace UserDashboard.Models
{
    public class Tasker
    {
        [Key]
        public int TaskerId { get; set; }
        public string TaskerDescription { get; set; }

        [DataType(DataType.Date)]
        [Required]
        public DateTime TaskerDueDate { get; set; }
        public int UserId { get; set; }
        public User TaskerOwner { get; set; }
        public int ProjectId { get; set; }
        public Project ProjectOfTasker { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}