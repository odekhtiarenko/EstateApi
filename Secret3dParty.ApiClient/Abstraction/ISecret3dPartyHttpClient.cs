using Secret3dParty.ApiClient.Contracts;
using System.Threading.Tasks;

namespace Secret3dParty.ApiClient.Abstraction
{
    public interface ISecret3dPartyHttpClient
    {
        Task<RealEstatesResponse> GetRealEstates(string location, int page, int pagesize, string filter = null);
    }
}
