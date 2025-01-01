using ASPWebApp.Enum;
using System.ComponentModel.DataAnnotations;

namespace ASPWebApp.Model
{
    public class AccountRegister
    {
       
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 5, ErrorMessage = "Password must be between 5 and 60 characters.")]
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Address { get; set; }

        public string AccessToken { get; set; }
    }
}
