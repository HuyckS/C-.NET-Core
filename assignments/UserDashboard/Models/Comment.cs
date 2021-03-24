using System;
using System.ComponentModel.DataAnnotations;
namespace UserDashboard.Models
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }

        public string CommentContent { get; set; }

        public string CommentPriority { get; set; }

        public int UserId { get; set; }
        public User CreatorOfComment { get; set; }

        public int MessageId { get; set; }
        public Message MessageOfComment { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}