using Core.Entities.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Concrete
{
    [Table("Payments")]
    public class Payment : IEntity
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal TotalPrice { get; set; }
        public string Type { get; set; }
        public string InvoiceAddress { get; set; }
        public string ShippedAddress { get; set; }
        public bool IsCompleted { get; set; }
        public string TransactionId { get; set; }
        public int CartID { get; set; }
        public int AccountID { get; set; }
        [ForeignKey("CardId")]
        public virtual Cart Cart { get; set; }
        [ForeignKey("AccountID")]
        public virtual Account Account { get; set; }
    }
}
