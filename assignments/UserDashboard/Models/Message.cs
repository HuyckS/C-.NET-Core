using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace UserDashboard.Models
{
    public class Message
    {
        [Key]
        public int MessageId { get; set; }
        public bool Viewed { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "Must be longer than 3 characters.")]
        public string MessageContent { get; set; }

        [Required]
        public int SenderId { get; set; }
        public User Sender { get; set; }


        // public int RecipientId { get; set; }
        // public User Recipient { get; set; }
        public List<Comment> CommentsOnMessage { get; set; }
        public int ProjectId { get; set; }
        public Project ProjectWithMessage { get; set; }


        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}