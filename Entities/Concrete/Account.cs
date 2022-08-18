using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Account:IEntity
    {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string ContactEmail { get; set; }
        public string IsBlocked { get; set; }
        public string IsApplyment { get; set; }
        public AccountType Type { get; set; }
        public virtual List<Product> Products { get; set; }
        public virtual List<Cart> Carts { get; set; }
        public virtual List<Payment> Payments { get; set; }
    }
    public enum AccountType
    {
        Admin,
        Member,
        Merchant
    }
}
