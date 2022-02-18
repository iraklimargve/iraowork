using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project1.Models
{
    public class MarketCompany
    {
        [Key, Column(Order = 0)]
        public int Id { get; set; }
        [Column(Order = 1)]
        public int MarketId { get; set; }
        [Column(Order = 2)]
        public int CompanyId { get; set; }

        public virtual Market Market { get; set; }
        public virtual Company Company { get; set; }

        public decimal Price { get; set; }
    }
}
