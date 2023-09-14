using Microsoft.AspNetCore.Mvc;
using ServiceContracts;
using ServiceContracts.DTO;

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

        [Route("/")]
        public IActionResult Index()
        {
            List<PersonResponse> people = _personsService.GetAllPersons();

            return View(people);
        }
    }
}
