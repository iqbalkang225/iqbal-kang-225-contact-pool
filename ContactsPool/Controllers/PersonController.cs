using Microsoft.AspNetCore.Mvc;
using ServiceContracts;
using ServiceContracts.DTO;
using ServiceContracts.Enums;

namespace ContactsPool.Controllers
{
    public class PersonController : Controller
    {
        private readonly ICountriesService _countriesService;
        private readonly IPersonsService _personsService;

        public PersonController(ICountriesService countriesService, IPersonsService personsService)
        {
            _countriesService = countriesService;
            _personsService = personsService;
        }

        [Route("/contacts")]
        [Route("/")]
        public IActionResult Index(string searchBy, string? searchString, 
                                    string sortBy = nameof(PersonResponse.PersonName), 
                                    SortOrderOptions sortOrder = SortOrderOptions.ASC)
        {
            Dictionary<string, string> selectInputFields = new Dictionary<string, string>()
            {
                { nameof(PersonResponse.PersonName), "Person Name" },
                { nameof(PersonResponse.Email), "Email" },
                { nameof(PersonResponse.DateOfBirth), "Date Of Birth" },
                { nameof(PersonResponse.Gender), "Gender" },
                { nameof(PersonResponse.CountryId), "Country" },
                { nameof(PersonResponse.Address), "Address" },
            };

            ViewBag.SelectInputFields = selectInputFields;
            ViewBag.CurrentSearchBy = searchBy;
            ViewBag.CurrentSearchString = searchString;

            //Search
            List<PersonResponse> people = _personsService.GetFilteredPerson(searchBy, searchString);

            //Sorting
            List<PersonResponse> sortedPersons = _personsService.GetSortedPersons(people, sortBy, sortOrder);
            ViewBag.CurrentSortBy = sortBy;
            ViewBag.CurrentSortOrder = sortOrder.ToString();

            return View(sortedPersons);
        }
    }
}
