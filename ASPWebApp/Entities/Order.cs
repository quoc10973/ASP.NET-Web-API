using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

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

        [JsonIgnore]
        public Account Account { get; set; }
    }
}
