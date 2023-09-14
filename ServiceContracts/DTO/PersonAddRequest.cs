using Entities;
using ServiceContracts.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace ServiceContracts.DTO
{
    public class PersonAddRequest
    {
        [Required(ErrorMessage = "person name is required.")]
        public string? PersonName { get; set; }

        [Required(ErrorMessage = "email is required.")]
        [EmailAddress(ErrorMessage = "email address is not valid.")]
        public string? Email { get; set; }

        public GenderOptions? Gender { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public Guid? CountryId { get; set; }

        public string? Address { get; set; }

        public bool ReceiveNewsletter { get; set; }

        public Person ToPerson()
        {
            return new Person()
            {
                PersonName = PersonName,
                Email = Email,
                Gender = Gender.ToString(),
                DateOfBirth = DateOfBirth,
                CountryId = CountryId,
                Address = Address,
                ReceiveNewsletter = ReceiveNewsletter
            };
        }
    }
}
