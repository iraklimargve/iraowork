using System.ComponentModel.DataAnnotations;

namespace Project1.Models
{
    public class TestModel
    {
        [Key]
        public int Id { get; set; }
        [StringLength(100)]
        [Required]
        public string Name { get; set; }
    }
}
