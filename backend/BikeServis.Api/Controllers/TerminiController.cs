using BikeServis.Api.Models;
using BikeServis.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace BikeServis.Api.Controllers;

public record ZakaziTerminRequest(string KlijentIme, string Usluga, DateTime Datum);

[ApiController]
[Route("api/termini")]
public class TerminiController : ControllerBase
{
    private readonly TerminService _servis;

    public TerminiController(TerminService servis) => _servis = servis;

    [HttpGet]
    public async Task<ActionResult<List<Termin>>> Get() =>
        await _servis.VratiSveAsync();

    [HttpPost]
    public async Task<ActionResult<Termin>> Post(ZakaziTerminRequest zahtjev)
    {
        try
        {
            var termin = await _servis.ZakaziAsync(zahtjev.KlijentIme, zahtjev.Usluga, zahtjev.Datum);
            return Created($"/api/termini/{termin.Id}", termin);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { poruka = ex.Message });
        }
    }
}
