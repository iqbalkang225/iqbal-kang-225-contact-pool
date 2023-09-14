using Entities;
using ServiceContracts;
using ServiceContracts.DTO;
using Services.Helpers;
using System;
using System.ComponentModel.DataAnnotations;

namespace Services
{
    public class PersonsService : IPersonsService
    {
        private readonly List<Person> _persons;

        private readonly ICountriesService _countriesService;

        public PersonsService(bool initialize = true)
        {
            _persons = new List<Person>();
            _countriesService = new CountriesService();

            if (initialize)
            {
                _persons.Add(new Person() { PersonId = Guid.Parse("8082ED0C-396D-4162-AD1D-29A13F929824"), PersonName = "Aguste", Email = "aleddy0@booking.com", DateOfBirth = DateTime.Parse("1993-01-02"), Gender = "Male", Address = "0858 Novick Terrace", ReceiveNewsletter = false, CountryId = Guid.Parse("000C76EB-62E9-4465-96D1-2C41FDB64C3B") });

                _persons.Add(new Person() { PersonId = Guid.Parse("06D15BAD-52F4-498E-B478-ACAD847ABFAA"), PersonName = "Jasmina", Email = "jsyddie1@miibeian.gov.cn", DateOfBirth = DateTime.Parse("1991-06-24"), Gender = "Female", Address = "0742 Fieldstone Lane", ReceiveNewsletter = true, CountryId = Guid.Parse("32DA506B-3EBA-48A4-BD86-5F93A2E19E3F") });

                _persons.Add(new Person() { PersonId = Guid.Parse("D3EA677A-0F5B-41EA-8FEF-EA2FC41900FD"), PersonName = "Kendall", Email = "khaquard2@arstechnica.com", DateOfBirth = DateTime.Parse("1993-08-13"), Gender = "Male", Address = "7050 Pawling Alley", ReceiveNewsletter = false, CountryId = Guid.Parse("32DA506B-3EBA-48A4-BD86-5F93A2E19E3F") });

                _persons.Add(new Person() { PersonId = Guid.Parse("89452EDB-BF8C-4283-9BA4-8259FD4A7A76"), PersonName = "Kilian", Email = "kaizikowitz3@joomla.org", DateOfBirth = DateTime.Parse("1991-06-17"), Gender = "Male", Address = "233 Buhler Junction", ReceiveNewsletter = true, CountryId = Guid.Parse("DF7C89CE-3341-4246-84AE-E01AB7BA476E") });

                _persons.Add(new Person() { PersonId = Guid.Parse("F5BD5979-1DC1-432C-B1F1-DB5BCCB0E56D"), PersonName = "Dulcinea", Email = "dbus4@pbs.org", DateOfBirth = DateTime.Parse("1996-09-02"), Gender = "Female", Address = "56 Sundown Point", ReceiveNewsletter = false, CountryId = Guid.Parse("DF7C89CE-3341-4246-84AE-E01AB7BA476E") });

                _persons.Add(new Person() { PersonId = Guid.Parse("A795E22D-FAED-42F0-B134-F3B89B8683E5"), PersonName = "Corabelle", Email = "cadams5@t-online.de", DateOfBirth = DateTime.Parse("1993-10-23"), Gender = "Female", Address = "4489 Hazelcrest Place", ReceiveNewsletter = false, CountryId = Guid.Parse("15889048-AF93-412C-B8F3-22103E943A6D") });

                _persons.Add(new Person() { PersonId = Guid.Parse("3C12D8E8-3C1C-4F57-B6A4-C8CAAC893D7A"), PersonName = "Faydra", Email = "fbischof6@boston.com", DateOfBirth = DateTime.Parse("1996-02-14"), Gender = "Female", Address = "2010 Farragut Pass", ReceiveNewsletter = true, CountryId = Guid.Parse("80DF255C-EFE7-49E5-A7F9-C35D7C701CAB") });

                _persons.Add(new Person() { PersonId = Guid.Parse("7B75097B-BFF2-459F-8EA8-63742BBD7AFB"), PersonName = "Oby", Email = "oclutheram7@foxnews.com", DateOfBirth = DateTime.Parse("1992-05-31"), Gender = "Male", Address = "2 Fallview Plaza", ReceiveNewsletter = false, CountryId = Guid.Parse("80DF255C-EFE7-49E5-A7F9-C35D7C701CAB") });

                _persons.Add(new Person() { PersonId = Guid.Parse("6717C42D-16EC-4F15-80D8-4C7413E250CB"), PersonName = "Seumas", Email = "ssimonitto8@biglobe.ne.jp", DateOfBirth = DateTime.Parse("1999-02-02"), Gender = "Male", Address = "76779 Norway Maple Crossing", ReceiveNewsletter = false, CountryId = Guid.Parse("80DF255C-EFE7-49E5-A7F9-C35D7C701CAB") });

                _persons.Add(new Person() { PersonId = Guid.Parse("6E789C86-C8A6-4F18-821C-2ABDB2E95982"), PersonName = "Freemon", Email = "faugustin9@vimeo.com", DateOfBirth = DateTime.Parse("1996-04-27"), Gender = "Male", Address = "8754 Becker Street", ReceiveNewsletter = false, CountryId = Guid.Parse("80DF255C-EFE7-49E5-A7F9-C35D7C701CAB") });

            }
        }
        public PersonResponse AddPerson(PersonAddRequest? request)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            //if (request.PersonName == null) throw new ArgumentException("Person name cannot be empty");

            ValidationHelper.ModelValidation(request);

            Person person = request.ToPerson();
            person.PersonId = Guid.NewGuid();

            return ConvertToPersonResponse(person);
        }

        public List<PersonResponse> GetAllPersons()
        {
            return _persons.Select(temp => ConvertToPersonResponse(temp)).ToList();
        }

        public PersonResponse? GetPersonByPersonId(Guid? personId)
        {
            if (personId == null) return null;

            Person? person = _persons.FirstOrDefault(person =>  person.PersonId == personId);

            if (person == null) return null;

            return ConvertToPersonResponse(person);
        }

        public List<PersonResponse> GetFilteredPerson(string searchBy, string? searchString)
        {
            List<PersonResponse> allPersons = GetAllPersons();
            List<PersonResponse> filteredPersons = allPersons;

            if (string.IsNullOrEmpty(searchString) || string.IsNullOrEmpty(searchBy))
            {
                return filteredPersons;
            }

            switch(searchBy)
            {
                case nameof(Person.PersonName):
                    filteredPersons = allPersons.Where(temp =>
                    {
                        return !string.IsNullOrEmpty(temp.PersonName) ? temp.PersonName.Contains(searchString) : true;
                    }).ToList();
                    break;

                case nameof(Person.Email):
                    filteredPersons = allPersons.Where(temp =>
                    {
                        return !string.IsNullOrEmpty(temp.Email) ? temp.Email.Contains(searchString) : true;
                    }).ToList();
                    break;

                case nameof(Person.Address):
                    filteredPersons = allPersons.Where(temp =>
                    {
                        return !string.IsNullOrEmpty(temp.Address) ? temp.Address.Contains(searchString) : true;
                    }).ToList();
                    break;

                case nameof(Person.Gender):
                    filteredPersons = allPersons.Where(temp =>
                    {
                        return !string.IsNullOrEmpty(temp.Gender) ? temp.Gender.Contains(searchString) : true;
                    }).ToList();
                    break;

                case nameof(Person.DateOfBirth):
                    filteredPersons = allPersons.Where(temp =>
                    {
                        return (temp.DateOfBirth != null) ? temp.DateOfBirth.Value.ToString("dd mm yyyy").Contains(searchString) : true;
                    }).ToList();
                    break;

                default: return filteredPersons = allPersons;

            }

            return filteredPersons;
        }

        private PersonResponse ConvertToPersonResponse(Person person)
        {
            PersonResponse personResponse = person.ToPersonResponse();
            personResponse.Country = _countriesService.GetCountryByCountryId(person.CountryId)?.CountryName;
            return personResponse;
        }
    }
}
