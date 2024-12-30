using System.ComponentModel.DataAnnotations;

namespace ASPWebApp.Model
{
    public class BookDTO
    {
        [MaxLength(100)]
        public string Title { get; set; }

        public string? Description { get; set; }

        [Range(0, double.MaxValue)]
        public double Price { get; set; }

        public string Author { get; set; }

        public int Quantity { get; set; }
    }
}
