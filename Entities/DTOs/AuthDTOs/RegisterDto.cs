using System.ComponentModel.DataAnnotations;

namespace Entities.DTOs.AuthDTOs
{
    public class RegisterDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        [Compare(nameof(Password))]
        public string RePassword { get; set; }
    }
}
