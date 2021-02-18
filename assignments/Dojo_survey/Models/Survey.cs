using System.ComponentModel.DataAnnotations;

namespace Dojo_survey.Models
{
    public class Survey
    {
        [Required(ErrorMessage = "You must enter a name.")]
        [MinLength(2, ErrorMessage = "Name must be at least 2 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "You must choose a location.")]
        public string Location { get; set; }

        [Required(ErrorMessage = "You must choose a language.")]
        public string Language { get; set; }

        [MinLength(20, ErrorMessage = "Please enter a comment greater than 20 characters.")]
        public string Comment { get; set; }

    }
}