using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CSharpExam2.Models
{
    public class LoginUser
    {
        [Required]
        [Display(Name = "Username")]
        public string LoginUsername { get; set; }

        [Required]
        [Display(Name = "Password")]
        public string LoginPassword { get; set; }
    }
}