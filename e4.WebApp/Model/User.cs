using System.ComponentModel.DataAnnotations;

namespace e4.WebApp.Model
{
    public class User
    {

        [Required]
        [RegularExpression(@"^(?:\+27|0)[1-9]\d{8}$", ErrorMessage = "Please enter a valid South African cellphone number.")]
        public string Cellphone { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }
    }

}
