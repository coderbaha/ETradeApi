using System.ComponentModel.DataAnnotations;

namespace Entities.DTOs.AuthDTOs
{
    public class AccountDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        [Compare(nameof(Password))]
        public string RePassword { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string ContactEmail { get; set; }
    }
}
