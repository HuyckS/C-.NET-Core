using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace UserDashboard.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        public string Status { get; set; }

        [Required]
        [Display(Name = "First Name")]
        [MinLength(2, ErrorMessage = "First Name must be 2 characters or longer!")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [MinLength(2, ErrorMessage = "Last Name must be 2 characters or longer!")]
        public string LastName { get; set; }

        [NotMapped]
        public string FullName
        {
            get { return FirstName + LastName; }
        }

        [EmailAddress]
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Required]
        [MinLength(8, ErrorMessage = "Password must be 8 characters or longer!")]
        public string Password { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        [NotMapped]
        [Compare("Password")]
        [DataType(DataType.Password)]
        public string Confirm { get; set; }

        public List<Project> CreatedProjects { get; set; }
        public List<Assignment> AssignedProjects { get; set; }
        public List<Tasker> AssignedTaskers { get; set; }
        public List<Message> MessagesSent { get; set; }
        public List<Comment> UserComments { get; set; }

    }
}