using ServiceContracts.DTO;
using System;

namespace ServiceContracts
{
    public interface IPersonsService
    {
        PersonResponse AddPerson(PersonAddRequest? request);

        List<PersonResponse> GetAllPersons();

        PersonResponse? GetPersonByPersonId(Guid? personId);

        List<PersonResponse> GetFilteredPerson(string searchBy, string? searchString);
    }
}
