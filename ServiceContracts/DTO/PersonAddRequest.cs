using Entities;
using ServiceContracts.Enums;
using System;


namespace ServiceContracts.DTO
{
    public class PersonAddRequest
    {
        public string? PersonName { get; set; }

        public string? Email { get; set; }

        public GenderOptions? Gender { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public Guid? CountryId { get; set; }

        public string? Address { get; set; }

        public bool RecieveNewsletter { get; set; }

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
                RecieveNewsletter = RecieveNewsletter
            };
        }
    }
}
