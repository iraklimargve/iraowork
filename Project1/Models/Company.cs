using System.ComponentModel.DataAnnotations;

namespace Project1.Models
{
    public class Company
    {
        [Key]
        public int Id { get; set; } 
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }

        public virtual ICollection<MarketCompany> MarketCompanies { get; set; }
    }
}
