using System.ComponentModel.DataAnnotations;

namespace DAL.DTOs
{
    public class ProductEntity
    {
        [Key]
        public int ProductID { get; set; }
        [Required]
        [MaxLength(40)]
        public string ProductName { get; set; }
        [MaxLength(20)]
        public string QuantityPerUnit { get; set; }
        public decimal UnitPrice { get; set; }
        public short UnitsInStock { get; set; }
        public short UnitsOnOrder { get; set; }
        public short ReorderLevel { get; set; }
        [Required]
        public bool Discontinued { get; set; }
        public int SupplierID { get; set; }
        public int CategoryID { get; set; }
        public virtual SupplierEntity Supplier { get; set; }
        public virtual CategoryEntity Category { get; set; }
    }
}
