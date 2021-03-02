using System;
using System.ComponentModel.DataAnnotations;
namespace CSharpExam2.Models
{
    public class Enthusiast
    {
        [Key]
        public int EnthusiastId { get; set; }

        [Display(Name = "Proficiency")]
        public string EnthusiastProficiency { get; set; }
        public int UserId { get; set; }
        public User UserWhoIsEnthused { get; set; }
        public int HobbyId { get; set; }
        public Hobby HobbyEnthusedAbout { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}