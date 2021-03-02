using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CSharpExam2.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [Display(Name = "First Name")]
        [MinLength(2, ErrorMessage = "First Name must be 2 characters or longer!")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [MinLength(2, ErrorMessage = "Last Name must be 2 characters or longer!")]
        public string LastName { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "Username must be greater than 3 characters.")]
        [MaxLength(15, ErrorMessage = "Username must be less 15 characters.")]
        public string Username { get; set; }

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

        public List<Hobby> CreatedHobbies { get; set; }
        public List<Enthusiast> EnthusiastOf { get; set; }

    }
}