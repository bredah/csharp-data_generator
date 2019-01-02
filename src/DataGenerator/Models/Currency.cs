namespace DataGenerator.Models
{
    /// <summary>
    ///     Currency Properties
    /// </summary>
    public class Currency
    {
        public string Name { get; set; }
        public string Alpha2Code { get; set; }
        public string Alpha3Code { get; set; }
        public string CurrencyName { get; set; }
        public string CurrencyCode { get; set; }
        public string CurrencySymbol { get; set; }

        public override string ToString()
        {
            return $"{Name},{Alpha2Code},{Alpha3Code},{CurrencyCode},{CurrencyName},{CurrencySymbol},";
        }
    }
}