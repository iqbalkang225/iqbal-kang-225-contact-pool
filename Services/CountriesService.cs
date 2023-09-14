using Entities;
using ServiceContracts;
using ServiceContracts.DTO;

namespace Services
{
    public class CountriesService : ICountriesService
    {
        private readonly List<Country> _countries = new List<Country>();

        public CountriesService(bool initialize = true)
        {
            if(initialize)
            {
                _countries.AddRange(new List<Country>()
                {
                    new Country() {  CountryId = Guid.Parse("000C76EB-62E9-4465-96D1-2C41FDB64C3B"), CountryName = "USA" },

                    new Country() { CountryId = Guid.Parse("32DA506B-3EBA-48A4-BD86-5F93A2E19E3F"), CountryName = "Canada" },

                    new Country() { CountryId = Guid.Parse("DF7C89CE-3341-4246-84AE-E01AB7BA476E"), CountryName = "UK" },

                    new Country() { CountryId = Guid.Parse("15889048-AF93-412C-B8F3-22103E943A6D"), CountryName = "India" },

                    new Country() { CountryId = Guid.Parse("80DF255C-EFE7-49E5-A7F9-C35D7C701CAB"), CountryName = "Australia" }
                });
            }
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
            _countries.Add(country);

            // Convert the country object into response object of CountryResponse type and return it
            return country.ToCountryResponse();

        }

        public List<CountryResponse> GetAllCountries()
        {
            // Iterate throught the list of countries
            // Convert the country object into response object of CountryResponse type and return it
            return _countries.Select(country =>  country.ToCountryResponse()).ToList();
        }

        public CountryResponse? GetCountryByCountryId(Guid? countryId)
        {
            // If countryId is null, then return null
            if (countryId == null) return null;

            // Find the first occurence of country with the given countryId
            // Return default value of null, if no country is found
            Country? country = _countries.FirstOrDefault(temp => temp.CountryId == countryId);

            // If no country is found, return null
            if (country == null) return null;

            // Convert the country object into response object of CountryResponse type and return it
            return country.ToCountryResponse();
        }

        private int IsCountryDuplicate(CountryAddRequest request)
        {
           return _countries.Where(temp => temp.CountryName == request.CountryName ).Count();
        }

    }
}