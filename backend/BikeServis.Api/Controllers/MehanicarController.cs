namespace BikeServis.Services
{
    public class MehanicarService
    {
        public List<string> PreuzmiTerminePoMehanicaru(int mehanicarId)
        {
            // Simulacija dohvatanja dodijeljenih termina za mehaničara
            return new List<string>
            {
                "Termin #1 - Servis kočnica (10:00h)",
                "Termin #2 - Zamjena lanca (13:30h)"
            };
        }
    }
}