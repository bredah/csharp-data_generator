using System.Net.Http;
using System.Threading.Tasks;
using DataGenerator.Models;
using Newtonsoft.Json;

namespace DataGenerator
{
    public class CountrySearch
    {
        /// <summary>
        ///     Search the country by the ISO Code
        /// </summary>
        /// <param name="country">ISO code with 2 or 3 letters</param>
        public HttpResponseMessage GetCountry(string country = "us")
        {
            return new HttpClient().GetAsync($"https://restcountries.eu/rest/v2/alpha/{country}").Result;
        }

        /// <summary>
        /// Parse response to the Currency object
        /// </summary>
        /// <param name="response">Value obtained from the method GetCountry</param>
        /// <returns>Object filled</returns>
        public static async Task<Currency> ParseMessage(HttpResponseMessage response)
        {
            if (response == null) return null;
            dynamic responseContent =
                JsonConvert.DeserializeObject(await response.Content.ReadAsStringAsync());
            return new Currency
            {
                Name = responseContent["name"].ToString(),
                Alpha2Code = responseContent["alpha2Code"].ToString(),
                Alpha3Code = responseContent["alpha3Code"].ToString(),
                CurrencyCode = responseContent["currencies"][0]["code"].ToString(),
                CurrencyName = responseContent["currencies"][0]["name"].ToString(),
                CurrencySymbol = responseContent["currencies"][0]["symbol"].ToString()
            };
        }
    }
}