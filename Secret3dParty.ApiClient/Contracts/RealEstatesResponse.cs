using System.Collections.Generic;

namespace Secret3dParty.ApiClient.Contracts
{
    public class RealEstatesResponse
    {
        public IEnumerable<Property> Objects { get; set; }
        public Paging Paging { get; set; }
    }
}
