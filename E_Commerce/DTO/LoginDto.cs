using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace E_Commerce.DTO
{
    public class LoginDto
    {
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }


    }
}
