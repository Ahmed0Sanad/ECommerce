using System.ComponentModel.DataAnnotations;

namespace E_Commerce.DTO
{
    public class RegisterDto
    {
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string Name { get; set; }
        [Phone]
        public string PhoneNumber { get; set; }


    }
}
