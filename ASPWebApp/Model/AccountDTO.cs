using ASPWebApp.Enum;
using System.ComponentModel.DataAnnotations;

namespace ASPWebApp.Model
{
    public class AccountDTO
    {
        public string Id { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Role Role { get; set; }

        public string Address { get; set; }

        public string AccessToken { get; set; }
    }
}
