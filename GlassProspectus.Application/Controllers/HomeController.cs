using Microsoft.AspNetCore.Mvc;

namespace GlassProspectus.Application
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        [Route("Get")]
        public string Get()
        {
            return "Index";
        }
    }
}
