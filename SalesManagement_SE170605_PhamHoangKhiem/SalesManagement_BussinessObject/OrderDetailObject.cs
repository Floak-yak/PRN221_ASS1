using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagement_BussinessObject
{
    public class OrderDetailObject
    {
        [Required]
        [Key]
        public int OrderId { get; set; }
        [Required]
        [ForeignKey(nameof(ProductObject.ProductId))]
        public int ProductId { get; set;}
        [Required]
        public Decimal UnitPrice { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public float Discount { get; set; } 
    }
}
