using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASPWebApp.Entities
{
    [Table("Books")]
    public class Book
    {
        [Key]
        public long Id { get; set; }

        [MaxLength(100)]
        public string Title { get; set; }

        public string? Description { get; set; }

        [Range(0, double.MaxValue)]
        public double Price { get; set; }
        
        public string Author { get; set; }

        public int Quantity { get; set; }
    }
}
