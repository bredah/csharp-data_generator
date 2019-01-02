using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace DataGenerator.Tests
{
    public class CountrySearchTest
    {
        private readonly CountrySearch _countrySearch;

        public CountrySearchTest()
        {
            _countrySearch = new CountrySearch();
        }

        [Fact]
        public void GetCountry_InvalidCountryCode_AlphaCode2()
        {
            var response = _countrySearch.GetCountry("zz");
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public void GetCountry_InvalidCountryCode_AlphaCode3()
        {
            var response = _countrySearch.GetCountry("zzz");
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public void GetCountry_ValidateRequest()
        {
            var response = _countrySearch.GetCountry();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task GetCountry_ParseData()
        {
            var response = _countrySearch.GetCountry();
            var result = await CountrySearch.ParseMessage(response);
            Assert.Equal("United States of America", result.Name);
            Assert.Equal("US", result.Alpha2Code);
            Assert.Equal("USA", result.Alpha3Code);
            Assert.Equal("USD", result.CurrencyCode);
            Assert.Equal("United States dollar", result.CurrencyName);
            Assert.Equal("$", result.CurrencySymbol);
        }
    }
}