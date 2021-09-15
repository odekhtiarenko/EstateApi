using System;

namespace Secret3dParty.ApiClient.Contracts
{
    public class Property
    {
        public Guid Id { get; set; }
        public int MakelaarId { get; set; }
        public string MakelaarNaam { get; set; }
        public string Adres { get; set; }
        public string AangebodenSindsTekst { get; set; }
    }
}