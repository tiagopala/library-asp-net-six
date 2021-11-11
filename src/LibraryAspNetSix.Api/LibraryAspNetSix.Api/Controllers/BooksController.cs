namespace LibraryAspNetSix.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : ControllerBase
    {
        public BooksController(){ }

        [HttpGet]
        public IActionResult GetBooks()
        {
            return Ok(new { Teste = "ok" });
        }
    }
}
