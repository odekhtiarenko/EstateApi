using System.Collections.Generic;

namespace EstateApi.Data
{
    public class RealEstateAgent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Property> Properties { get; set; }
    }
}
