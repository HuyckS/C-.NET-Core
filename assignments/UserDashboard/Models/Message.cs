using System;
using System.ComponentModel.DataAnnotations;
namespace UserDashboard.Models
{
    public class Message
    {
        [Key]
        public int MessageId { get; set; }
        public string MessageContent { get; set; }
        public int UserId { get; set; }
        public User Sender { get; set; }
        public User Recipient { get; set;}
        public int ProjectId { get; set; }
        public Project ProjectWithMessage { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}