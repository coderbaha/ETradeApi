using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    [Table("Payments")]
    public class Payment : IEntity
    {
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
        public virtual Cart Cart { get; set; }
        public virtual Account Account { get; set; }
    }
}
