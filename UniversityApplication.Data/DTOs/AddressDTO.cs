using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using UniversityApplication.Data.Validators;

namespace UniversityApplication.Data.DTOs
{
    public class AddressDTO
    {
        [IdNotSend(ErrorMessage = "You cannot input an Id of an Address")]
        public int Id { get; set; }

        [StringLength(400, ErrorMessage = "The Street value cannot exceed 400 characters. ")]
        public string Street { get; set; }

        [StringLength(400, ErrorMessage = "The City value cannot exceed 400 characters. ")]
        public string City { get; set; }

        [StringLength(400, ErrorMessage = "The Country value cannot exceed 400 characters. ")]
        public string Country { get; set; }

    }
}
