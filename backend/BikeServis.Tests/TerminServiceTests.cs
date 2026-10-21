using BikeServis.Api.Data;
using BikeServis.Api.Models;
using BikeServis.Api.Services;
using Microsoft.EntityFrameworkCore;

namespace BikeServis.Tests;

public class TerminServiceTests
{
    private static TerminService NapraviServis()
    {
        var opcije = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;
        return new TerminService(new AppDbContext(opcije));
    }

    [Fact]
    public async Task Zakazi_ValidniPodaci_PostavljaStatusZakazan()
    {
        var servis = NapraviServis();
        var termin = await servis.ZakaziAsync("Amar", "Veliki servis", DateTime.Now.AddDays(3));
        Assert.Equal(StatusTermina.Zakazan, termin.Status);
    }

    [Fact]
    public async Task Zakazi_TerminUProslosti_BacaIzuzetak()
    {
        var servis = NapraviServis();
        await Assert.ThrowsAsync<ArgumentException>(() =>
            servis.ZakaziAsync("Amar", "Veliki servis", DateTime.Now.AddDays(-1)));
    }

    [Fact]
    public async Task Zakazi_BezImena_BacaIzuzetak()
    {
        var servis = NapraviServis();
        await Assert.ThrowsAsync<ArgumentException>(() =>
            servis.ZakaziAsync("", "Veliki servis", DateTime.Now.AddDays(3)));
    }
}
