using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    [Table("CartProducts")]
    public class CartProduct:IEntity
    {
        [Key]
        public int Id { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal DiscountedPrice { get; set; }
        public int Quantity { get; set; }
        public int? CartId { get; set; }
        public int? ProductId { get; set; }
        public virtual Product Product { get; set; }
        public virtual Cart Cart { get; set; }

    }
}
