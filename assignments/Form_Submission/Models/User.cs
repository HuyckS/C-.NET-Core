using System.ComponentModel.DataAnnotations;

namespace Form_Submission.Models
{
    public class User
    {
        [Required(ErrorMessage = "You must enter a first name.")]
        [MinLength(4, ErrorMessage = "First name must be at least 4 characters.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "You must enter a last name.")]
        [MinLength(4, ErrorMessage = "Last name must be at least 4 characters.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "You must enter an age.")]
        [Range(1, 150, ErrorMessage = "Age must be a positive number between 1 and 150.")]
        public int Age { get; set; }

        [Required(ErrorMessage = "You must enter a valid email: example@gmail.com.")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "You must enter a password.")]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters.")]
        public string Password { get; set; }
    }
}