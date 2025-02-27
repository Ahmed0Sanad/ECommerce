using System.ComponentModel.DataAnnotations;

namespace E_Commerce.DTO
{
    public class UserDto
    {
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string Token { get; set; }
    }
}
