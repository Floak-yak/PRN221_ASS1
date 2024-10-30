using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagement_BussinessObject
{
    public class OrderObject
    {
        [Key]
        [Required]
        public int OrderId { get; set; }
        [ForeignKey(nameof(MemberObject.MemberId))]
        [Required]
        public int MemberId { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }
        [Required]
        public DateTime RequiredDate { get; set; }
        [Required]
        public DateTime ShippedDate { get; set; }
        [Required]
        public Decimal Freight { get; set; }
        public virtual ICollection<OrderDetailObject> Details { get; set; }
    }
}
