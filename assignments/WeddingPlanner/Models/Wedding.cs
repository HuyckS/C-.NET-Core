using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace WeddingPlanner.Models
{
    public class Wedding
    {
        [Key]
        public int WeddingId { get; set; }
        public string WedderOne { get; set; }
        public string WedderTwo { get; set; }

        [DataType(DataType.Date)]
        public DateTime WeddingDate { get; set; }
        public string WeddingAddress { get; set; }
        public List<RSVP> WeddingRSVPs { get; set; }

        public int UserId { get; set; }
        public User WeddingPlanner { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}