using System;
using System.ComponentModel.DataAnnotations;
namespace UserDashboard.Models
{
    public class Assignment
    {
        [Key]
        public int AssignmentId { get; set; }

        public int UserId { get; set; }
        public User UserForProject { get; set; }

        public int ProjectId { get; set; }
        public Project ProjectForUser { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}