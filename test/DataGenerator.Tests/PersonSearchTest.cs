using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace DataGenerator.Tests
{
    public class PersonSearchTest
    {
        private readonly PersonSearch _personSearch;

        public PersonSearchTest()
        {
            _personSearch = new PersonSearch();
        }

        [Fact]
        public void GetPerson_ValidateRequest()
        {
            var response = _personSearch.GetPerson();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task GetPerson_ValidateResponseData()
        {
            var response = _personSearch.GetPerson();
            var result = await PersonSearch.ParseMessage(response);

            Assert.NotNull(result.Name);
            Assert.NotNull(result.Surname);
            Assert.NotNull(result.Address);
            Assert.NotNull(result.Telephone);
            Assert.NotNull(result.Gender);
            Assert.NotNull(result.MaritalStatus);
            Assert.NotNull(result.Nationality);
            Assert.NotNull(result.City);
            Assert.NotNull(result.Email);
            Assert.NotNull(result.DateOfBirth);
            Assert.Null(result.Currency);
            Assert.Null(result.CountryOfBirth);
            Assert.Equal(0, result.GrossAnnualIncome);
        }
    }
}