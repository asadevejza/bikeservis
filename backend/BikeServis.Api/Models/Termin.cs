namespace BikeServis.Api.Models;

public class Termin
{
    public int Id { get; set; }
    public DateTime Datum { get; set; }
    public string KlijentIme { get; set; } = "";
    public string Usluga { get; set; } = "";
    public StatusTermina Status { get; set; } = StatusTermina.Zakazan;
}
