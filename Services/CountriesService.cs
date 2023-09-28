using Entities;
using ServiceContracts;
using ServiceContracts.DTO;

namespace Services
{
    public class CountriesService : ICountriesService
    {
        private readonly PersonDbContext _db;

        public CountriesService(PersonDbContext personDbContext)
        {
            _db = personDbContext;

        }

        public CountryResponse AddCountry(CountryAddRequest? request)
        {
            // Validation: request parameter cannot be null
            if (request == null) throw new ArgumentNullException(nameof(request));

            // Validation: countryName cannot be null
            if (request.CountryName == null) throw new ArgumentException(nameof(request.CountryName));

            // Validation: countryName should not already exist in the list
            if (IsCountryDuplicate(request) > 0) throw new ArgumentException("this country already exists");

            // Convert request from CountryAddRequest to Country type and add CountryId
            Country country = request.ToCountry();
            country.CountryId = Guid.NewGuid();

            // Add new country object into _countries List
            _db.Countries.Add(country);
            _db.SaveChanges();

            // Convert the country object into response object of CountryResponse type and return it
            return country.ToCountryResponse();

        }

        public List<CountryResponse> GetAllCountries()
        {
            // Iterate throught the list of countries
            // Convert the country object into response object of CountryResponse type and return it
            
            return _db.Countries.Select(country =>  country.ToCountryResponse()).ToList();
        }

        public CountryResponse? GetCountryByCountryId(Guid? countryId)
        {
            // If countryId is null, then return null
            if (countryId == null) return null;

            // Find the first occurence of country with the given countryId
            // Return default value of null, if no country is found
            Country? country = _db.Countries.FirstOrDefault(temp => temp.CountryId == countryId);

            // If no country is found, return null
            if (country == null) return null;

            // Convert the country object into response object of CountryResponse type and return it
            return country.ToCountryResponse();
        }

        private int IsCountryDuplicate(CountryAddRequest request)
        {
           return _db.Countries.Count(temp => temp.CountryName == request.CountryName );
        }

    }
}