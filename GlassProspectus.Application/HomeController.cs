using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GlassProspectus.Application
{
    public class HomeController : Controller
    {
        public string Index()
        {
            return "Index";
        }

        [Authorize]
        public string Authenticate()
        {
            return "Authenticated";
        }
    }
}
