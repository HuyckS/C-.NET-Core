using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace CSharpExam.Models
{
    public class ActivityEvent
    {
        [Key]
        public int ActivityEventId { get; set; }

        [Required]
        public string Title { get; set; }

        [DataType(DataType.Date)]
        [Required]
        public DateTime Date { get; set; }

        [DataType(DataType.Time)]
        [Required]
        public DateTime Time { get; set; }

        [Required]
        public int Duration { get; set; }

        [Required]
        public string TimeMeasurement { get; set; }

        [Required]
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public List<Participant> Participants { get; set; }
        public int UserId { get; set; }
        public User EventCoordinator { get; set; }
    }
}