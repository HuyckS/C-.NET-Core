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
        public string ProjectDescription { get; set; }

        [DataType(DataType.Date)]
        [Required]
        public DateTime ProjectStartDate { get; set; }

        [DataType(DataType.Date)]
        [Required]
        public DateTime ProjectDueDate { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        //Many Tasks assigned to 1 project
        public List<Tasker> ProjectTaskerList { get; set; }

        //Many users assigned to project
        public List<User> ProjectMembers { get; set; }

        //One user that creates project
        public int UserId { get; set; }
        public User ProjectCreator { get; set; }

        //Messages for project
        public int MessageId { get; set; }
        public List<Message> ProjectMessages { get; set; }
    }
}