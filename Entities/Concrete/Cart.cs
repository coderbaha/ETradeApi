using Core.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Concrete
{
    [Table("Carts")]
    public class Cart : IEntity
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public bool IsClosed { get; set; }
        public int AccountId { get; set; }
        [ForeignKey("AccountId")]
        public virtual Account Account { get; set; }
        public virtual List<CartProduct> CartProducts { get; set; }
        public Cart()
        {
            CartProducts = new List<CartProduct>();
        }
    }
}
