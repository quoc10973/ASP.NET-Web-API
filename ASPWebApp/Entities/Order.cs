using System.ComponentModel.DataAnnotations.Schema;

namespace ASPWebApp.Entities
{
    [Table("Orders")]
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string Address { get; set; }
        public double TotalPrice { get; set; }

        public Guid AccountId { get; set; }
        public Account Account { get; set; }
    }
}
