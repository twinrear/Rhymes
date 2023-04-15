using Microsoft.AspNetCore.Mvc;

namespace Rhymes.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class RhymesController : Controller
    {
        public IActionResult Index()
        {
            //WordBank.getInstance();
            return View();
        }

        //[HttpGet]
        public IActionResult Rhymes()
        {
            return View();
            //return View(WordBank.getInstance().GetRhymes(word));
        }

        [HttpGet]
        public IActionResult GetRhymes(string word)
        {
            if(word == null) 
                word = string.Empty;

            //ViewBag.words = WordBank.getInstance().GetRhymes(word);
            return Content(string.Join(", ", WordBank.getInstance().GetRhymes(word)));
            //return View(WordBank.getInstance().GetRhymes(word));
        }
    }
}
