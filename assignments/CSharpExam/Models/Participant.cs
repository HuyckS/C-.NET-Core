using System;
using System.ComponentModel.DataAnnotations;
namespace CSharpExam.Models
{
    public class Participant
    {
        [Key]
        public int ParticipantId { get; set; }
        public int UserId { get; set; }
        public User UserSignedUp { get; set; }
        public int ActivityEventId { get; set; }
        public ActivityEvent RegisteredActivity { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}