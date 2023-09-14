namespace CountriesDemo.Models
{
    public class Country
    {
        public int Id { get; set; }
        public string? CountryName { get; set; }

        public Country(int id, string? countryName)
        {
            Id = id;
            CountryName = countryName;
        }
    }
}
