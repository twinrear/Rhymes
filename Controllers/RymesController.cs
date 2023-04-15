using Microsoft.AspNetCore.Mvc;

namespace Rhymes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RymesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IEnumerable<string> GetRymes([FromBody] string word)
        {
            return WordBank.getInstance().GetRhymes(word);
        }
    }
}
