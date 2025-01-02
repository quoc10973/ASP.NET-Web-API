using ASPWebApp.Enum;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASPWebApp.Entities
{
    [Table("Account")]
    public class Account
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 5, ErrorMessage = "Password must be between 5 and 60 characters.")]
        public string Password { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Role Role { get; set; }

        public string Address { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
