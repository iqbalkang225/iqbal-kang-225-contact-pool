using Entities;

namespace ServiceContracts.DTO
{
    public class PersonResponse
    {
        public Guid PersonId { get; set; }

        public string? PersonName { get; set; }

        public string? Email { get; set; }

        public string? Gender { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public Guid? CountryId { get; set; }

        public string? Address { get; set; }

        public bool ReceiveNewsletter { get; set; }

        public double? Age {  get; set; }

        public string? Country {  get; set; }

    }

    public static class PersonExtensions
    {
        public static PersonResponse ToPersonResponse(this Person person)
        {
            return new PersonResponse()
            {
                PersonId = person.PersonId,
                PersonName = person.PersonName,
                Email = person.Email,
                Gender = person.Gender,
                DateOfBirth = person.DateOfBirth,
                CountryId = person.CountryId,
                Address = person.Address,
                ReceiveNewsletter = person.ReceiveNewsletter,
                Age = person.DateOfBirth != null 
                      ? Math.Round((DateTime.Now - person.DateOfBirth.Value).TotalDays / 365.25) 
                      : null
            };
        }
    }
}
