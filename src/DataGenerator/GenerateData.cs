using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using DataGenerator.Models;

namespace DataGenerator
{
    /// <summary>
    /// Generate the output file with the data
    /// </summary>
    public class GenerateData
    {
        public GenerateData()
        {
            Persons = new List<Person>();
        }

        /// <summary>
        /// List with the values generated
        /// </summary>
        public List<Person> Persons { get; }

        /// <summary>
        ///     Add a random register
        /// </summary>
        public async Task Add(Country countryCode = Country.US)
        {
            // Get a random person
            var person =
                await PersonSearch.ParseMessage(new PersonSearch().GetPerson(countryCode.ToString().ToLower()));
            // Get data
            var country =
                await CountrySearch.ParseMessage(new CountrySearch().GetCountry(countryCode.ToString().ToLower()));
            person.Currency = country.CurrencyCode;
            person.CountryOfBirth = country.Name;
            // Random gross salary
            person.GrossAnnualIncome = new Random().Next(20, 99) * 1000;
            // Store the value
            Persons.Add(person);
        }

        /// <summary>
        ///     Generate the output file
        /// </summary>
        /// <returns>File path</returns>
        public string GenerateFile()
        {
            var pathFile = $"{Helper.OutputPath}/data.csv";
            var builder = new StringBuilder();
            builder.AppendLine(
                "Name,Surname,Address,City,Telephone,Email,DateOfBirth,Gender,MaritalStatus,Nationality,CountryOfBirth,GrossAnnualIncome,Currency");
            foreach (var person in Persons) builder.AppendLine(person.ToString());
            File.WriteAllText(pathFile, builder.ToString(), Encoding.UTF8);
            return pathFile;
        }
    }
}