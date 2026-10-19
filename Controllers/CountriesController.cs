using CountryStatsAPI.Models;
using CountryStatsAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CountryStatsAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CountriesController(CountryService countryService) : ControllerBase
{
    [HttpGet]
    public ActionResult<List<Country>> GetAll() => countryService.GetAll();

    [HttpGet("{id:int}")]
    public ActionResult<Country> Get(int id)
    {
        var country = countryService.Get(id);
        return country is null ? NotFound() : country;
    }

    [HttpPost]
    public ActionResult<Country> Add(Country country)
    {
        countryService.Add(country);
        return CreatedAtAction(nameof(Get), new { id = country.Id }, country);
    }

    [HttpPut("{id:int}")]
    public IActionResult Update(int id, Country country)
    {
        if (countryService.Get(id) is null || country.Id != id)
            return NotFound();

        countryService.Update(id, country);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        if (countryService.Get(id) is null)
            return NotFound();

        countryService.Delete(id);
        return NoContent();
    }
}