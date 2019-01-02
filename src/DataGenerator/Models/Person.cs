namespace DataGenerator.Models
{
    public class Person
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public string DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string MaritalStatus { get; set; }
        public string Nationality { get; set; }
        public string CountryOfBirth { get; set; }
        public int GrossAnnualIncome { get; set; }
        public string Currency { get; set; }

        public override string ToString()
        {
            return
                $"{Name},{Surname},{Address},{City},{Telephone},{Email},{DateOfBirth},{Gender},{MaritalStatus},{Nationality},{CountryOfBirth},{GrossAnnualIncome.ToString()},{Currency}";
        }
    }
}