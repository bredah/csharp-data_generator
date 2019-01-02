using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace DataGenerator.Tests
{
    public class GenerateDataTest
    {
        private readonly GenerateData _generateData;

        public GenerateDataTest()
        {
            _generateData = new GenerateData();
        }

        [Fact]
        public async Task AddNewRegister()
        {
            await _generateData.Add();
            Assert.True(_generateData.Persons.Count > 0);
            Assert.Equal(Country.US.ToString(), _generateData.Persons[0].Nationality);
        }

        [Fact]
        public async Task AddNewRegister_RandomCountry()
        {
            var country = Helper.RandomEnumValue<Country>();
            await _generateData.Add(country);
            Assert.True(_generateData.Persons.Count > 0);
            Assert.Equal(country.ToString(), _generateData.Persons[0].Nationality);
        }

        [Fact]
        public async Task GenerateFile()
        {
            await _generateData.Add(Helper.RandomEnumValue<Country>());
            await _generateData.Add(Helper.RandomEnumValue<Country>());
            var result = _generateData.GenerateFile();
            Assert.True(File.Exists(result));
        }
    }
}