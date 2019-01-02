using System;
using System.Globalization;
using System.Net.Http;
using System.Threading.Tasks;
using DataGenerator.Models;
using Newtonsoft.Json;

namespace DataGenerator
{
    public class PersonSearch
    {
        /// <summary>
        ///     Search a country by the ISO Code
        /// </summary>
        /// <param name="country">ISO code with 2 or 3 letters</param>
        public HttpResponseMessage GetPerson(string country = "us")
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Accept",
                    @"text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8");
                return client.GetAsync($"https://randomuser.me/api/?nat={country}").Result;
            }
        }

        /// <summary>
        /// Parse response to the Currency object
        /// </summary>
        /// <param name="response">Value obtained from the method GetPerson</param>
        /// <returns>Object filled</returns>
        public static async Task<Person> ParseMessage(HttpResponseMessage response)
        {
            if (response == null) return null;
            dynamic responseContent =
                JsonConvert.DeserializeObject(await response.Content.ReadAsStringAsync());
            var results = responseContent.results;
            foreach (var result in results)
                return new Person
                {
                    Name = Helper.CapitalizeFirstLetter(result["name"]["first"].ToString()),
                    Surname = Helper.CapitalizeFirstLetter(result["name"]["last"].ToString()),
                    Address = result["location"]["street"].ToString(),
                    Telephone = result["cell"].ToString(),
                    Gender = result["gender"].ToString(),
                    Nationality = Helper.CapitalizeFirstLetter(result["nat"].ToString()),
                    City = Helper.CapitalizeFirstLetter(result["location"]["city"].ToString()),
                    Email = result["email"].ToString(),
                    DateOfBirth = DateTime.Parse(result["dob"]["date"].ToString(), CultureInfo.CurrentCulture)
                        .ToString("yyyy-MM-dd"),
                    MaritalStatus = GetRandomMaritalStatus(),
                    Currency = null,
                    CountryOfBirth = null,
                    GrossAnnualIncome = 0
                };

            return null;
        }

        /// <summary>
        ///     Get a Random Marital Status
        /// </summary>
        /// <returns>Random value from the <seealso cref="MaritalStatusValues" /></returns>
        private static string GetRandomMaritalStatus()
        {
            return Helper.RandomEnumValue<MaritalStatusValues>().ToString();
        }
    }
}