using System.Data.SqlClient;
using ToolShelfAPI.Data;
namespace ToolShelfAPI.Services
{
    public class HomeService:IHomeService
    {
        private readonly IHomeDataLayer _homeDataLayer;
        public HomeService(IHomeDataLayer homeDataLayer)
        {
            _homeDataLayer = homeDataLayer;
        }
        public List<ToolList> GetToolsList() {
            return _homeDataLayer.GetToolsList();
        }
    }
}
