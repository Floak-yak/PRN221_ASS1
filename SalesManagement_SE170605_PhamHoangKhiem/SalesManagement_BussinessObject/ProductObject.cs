using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagement_BussinessObject
{
    public class ProductObject
    {
        [Key]
        [Required]
        public int ProductId { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public string Weight { get; set; }
        [Required]
        public Decimal UnitPrice { get; set; }
        [Required]
        public int UnitStock { get; set; }
        public virtual ICollection<OrderDetailObject> OrderDetailObjects { get;}
    }
}
