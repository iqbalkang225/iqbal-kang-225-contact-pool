using ServiceContracts.DTO;
using ServiceContracts.Enums;
using System;

namespace ServiceContracts
{
    public interface IPersonsService
    {
        PersonResponse AddPerson(PersonAddRequest? request);

        List<PersonResponse> GetAllPersons();

        PersonResponse? GetPersonByPersonId(Guid? personId);

        List<PersonResponse> GetFilteredPerson(string searchBy, string? searchString);

        List<PersonResponse> GetSortedPersons(List<PersonResponse> persons, string sortBy, SortOrderOptions sortOrder);
    }
}
