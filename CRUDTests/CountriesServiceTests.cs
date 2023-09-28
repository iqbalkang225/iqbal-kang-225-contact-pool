using ServiceContracts;
using ServiceContracts.DTO;
using Services;
using Xunit;

namespace CRUDTests
{
    public class CountriesServiceTests
    {
        private readonly ICountriesService _countriesService;

        //public CountriesServiceTests()
        //{
        //    _countriesService = new CountriesService();
        //}

        #region AddCountry
        
        [Fact]
        public void AddCountry_NullCountry()
        {
            CountryAddRequest? request = null;

            Assert.Throws<ArgumentNullException>(() =>
            {
                _countriesService.AddCountry(request);
            });

        }

        [Fact]
        public void AddCountry_NullCountryName()
        {
            CountryAddRequest? request = new CountryAddRequest() { CountryName = null };

            Assert.Throws<ArgumentException>(() =>
            {
                _countriesService.AddCountry(request);
            });

        }

        [Fact]
        public void AddCountry_DuplicateCountryName()
        {
            CountryAddRequest? request1 = new CountryAddRequest() { CountryName = "usa" };
            CountryAddRequest? request2 = new CountryAddRequest() { CountryName = "usa" };

            Assert.Throws<ArgumentException>(() =>
            {
                _countriesService.AddCountry(request1);
                _countriesService.AddCountry(request2);
            });
        }

        [Fact]
        public void AddCountry_ProperCountryDetails()
        {
            CountryAddRequest request = new CountryAddRequest() { CountryName = "canada" };

            CountryResponse response = _countriesService.AddCountry(request);

            Assert.True(response.CountryId != Guid.Empty);
        }

        #endregion

        #region GetAllCountries

        [Fact]
        public void GetAllCountries_EmptyList()
        {

        }
        #endregion
    }
}