namespace CountriesDemo.Models
{
    public class Countries
    {
        private readonly Dictionary<int, Country> _countries = new()
        {
            {1, new Country(1, "United States")},
            {2, new Country(2, "Canada") },
            {3, new Country(3,"United Kingdom") },
            {4, new Country(4, "India") },
            {5, new Country(5, "Japan") }
        };

        public Dictionary<int, Country> GetCountries()
        {
            return _countries;
        }

        public Country GetCountry(int id)
        {
            return _countries[id];
        }
    }
}
