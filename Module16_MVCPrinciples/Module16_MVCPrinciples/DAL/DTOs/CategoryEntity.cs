using System.ComponentModel.DataAnnotations;

namespace DAL.DTOs
{
    public class CategoryEntity
    {
        [Key]
        public int CategoryID { get; set; }
        [Required]
        [MaxLength(15)]
        public string CategoryName { get; set; }
        public string Description { get; set; }
    }
}
