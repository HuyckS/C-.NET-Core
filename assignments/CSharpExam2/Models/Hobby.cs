using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace CSharpExam2.Models
{
    public class Hobby
    {
        [Key]
        public int HobbyId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public List<Enthusiast> HobbyEnthusiasts { get; set; }
        public int UserId { get; set; }
        public User HobbyCreator { get; set; }
    }
}