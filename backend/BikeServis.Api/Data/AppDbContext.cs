using BikeServis.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace BikeServis.Api.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Termin> Termini => Set<Termin>();
}
