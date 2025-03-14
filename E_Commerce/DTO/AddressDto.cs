﻿using System.ComponentModel.DataAnnotations;

namespace E_Commerce.DTO
{
    public class AddressDto
    {
        public int id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]

        public string LastName { get; set; }
        [Required]

        public string Street { get; set; }
        [Required]

        public string City { get; set; }
        [Required]

        public string Country { get; set; }
    }
}