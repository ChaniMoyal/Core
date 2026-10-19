using CountryStatsAPI.Models;

namespace CountryStatsAPI.Services;

public class CountryService
{
	private readonly List<Country> countries =
	[
		new Country { Id = 1, Name = "Israel", Continent = "Asia", Language = "Hebrew", Population = 9_800_000 },
		new Country { Id = 2, Name = "Italy", Continent = "Europe", Language = "Italian", Population = 58_900_000 },
		new Country { Id = 3, Name = "Japan", Continent = "Asia", Language = "Japanese", Population = 123_300_000 },
		new Country { Id = 4, Name = "France", Continent = "Europe", Language = "French", Population = 68_400_000 },
		new Country { Id = 5, Name = "Germany", Continent = "Europe", Language = "German", Population = 84_500_000 },
		new Country { Id = 6, Name = "Brazil", Continent = "South America", Language = "Portuguese", Population = 212_600_000 },
		new Country { Id = 7, Name = "Canada", Continent = "North America", Language = "English, French", Population = 41_500_000 },
		new Country { Id = 8, Name = "Egypt", Continent = "Africa", Language = "Arabic", Population = 116_500_000 },
		new Country { Id = 9, Name = "India", Continent = "Asia", Language = "Hindi, English", Population = 1_450_000_000 },
		new Country { Id = 10, Name = "China", Continent = "Asia", Language = "Mandarin Chinese", Population = 1_410_000_000 },
		new Country { Id = 11, Name = "Australia", Continent = "Oceania", Language = "English", Population = 27_200_000 },
		new Country { Id = 12, Name = "Mexico", Continent = "North America", Language = "Spanish", Population = 130_900_000 },
		new Country { Id = 13, Name = "South Africa", Continent = "Africa", Language = "Zulu, Xhosa, Afrikaans, English", Population = 64_000_000 },
		new Country { Id = 14, Name = "Spain", Continent = "Europe", Language = "Spanish", Population = 48_600_000 },
		new Country { Id = 15, Name = "Greece", Continent = "Europe", Language = "Greek", Population = 10_400_000 }
	];

	private int nextId = 16;

	public List<Country> GetAll() => countries;

	public Country? Get(int id) => countries.FirstOrDefault(country => country.Id == id);

	public void Add(Country country)
	{
		country.Id = nextId++;
		countries.Add(country);
	}

	public void Delete(int id)
	{
		var country = Get(id);
		if (country is null)
			return;

		countries.Remove(country);
	}

	public void Update(int id, Country country)
	{
		var index = countries.FindIndex(existing => existing.Id == id && country.Id == id);
		if (index == -1)
			return;

		countries[index] = country;
	}

	public int Count => countries.Count;
}
