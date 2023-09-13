using Entities;
using ServiceContracts;
using ServiceContracts.DTO;
using System;

namespace Services
{
    public class PersonsService : IPersonsService
    {
        private readonly ICountriesService _countriesService;
        public PersonsService()
        {
            _countriesService = new CountriesService();
        }
        public PersonResponse AddPerson(PersonAddRequest? request)
        {
            if(request == null) throw new ArgumentNullException(nameof(request));

            if (request.PersonName == null) throw new ArgumentException("Person name cannot be empty");

            Person person = request.ToPerson();
            person.PersonId = Guid.NewGuid();

            return ConvertToPersonResponse(person);
        }

        public List<PersonResponse> GetAllPersons()
        {
            throw new NotImplementedException();
        }

        private PersonResponse ConvertToPersonResponse(Person person)
        {
            PersonResponse personResponse = person.ToPersonResponse();
            personResponse.Country = _countriesService.GetCountryByCountryId(person.CountryId)?.CountryName;
            return personResponse;
        }
    }
}
