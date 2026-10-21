using BikeServis.Api.Data;
using BikeServis.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace BikeServis.Api.Services;

public class TerminService
{
    private readonly AppDbContext _db;

    public TerminService(AppDbContext db) => _db = db;

    public Task<List<Termin>> VratiSveAsync() =>
        _db.Termini.OrderBy(t => t.Datum).ToListAsync();

    public async Task<Termin> ZakaziAsync(string klijentIme, string usluga, DateTime datum)
    {
        if (string.IsNullOrWhiteSpace(klijentIme))
            throw new ArgumentException("Ime klijenta je obavezno.");
        if (string.IsNullOrWhiteSpace(usluga))
            throw new ArgumentException("Usluga je obavezna.");
        if (datum <= DateTime.Now)
            throw new ArgumentException("Termin mora biti u budućnosti.");

        var termin = new Termin { KlijentIme = klijentIme, Usluga = usluga, Datum = datum };
        _db.Termini.Add(termin);
        await _db.SaveChangesAsync();
        return termin;
    }
}
