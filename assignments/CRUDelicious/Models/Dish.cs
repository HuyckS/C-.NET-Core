using System;
using System.ComponentModel.DataAnnotations;

namespace CRUDelicious.Models
{
    public class Dish
    {
        [Key]
        public int DishId { get; set; }
        public string ChefName { get; set; }
        public string DishName { get; set; }
        public int Calories { get; set; }

        [Display(Name = "Tastiness")]
        [Range(1, 5)]
        public int Rating { get; set; }

        public string Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

    }
}