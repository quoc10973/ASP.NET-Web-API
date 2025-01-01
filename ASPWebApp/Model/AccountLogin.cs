using System.ComponentModel.DataAnnotations;

namespace ASPWebApp.Model
{
    public class AccountLogin
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
