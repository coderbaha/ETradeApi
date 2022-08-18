using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Concrete
{
    [Table("Carts")]
    public class Cart : IEntity
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public bool IsClosed { get; set; }
        public int AccountId { get; set; }
        public virtual Account Account { get; set; }
        public virtual List<CartProduct> CartProducts { get; set; }
        public Cart()
        {
            CartProducts = new List<CartProduct>();
        }
    }
}
