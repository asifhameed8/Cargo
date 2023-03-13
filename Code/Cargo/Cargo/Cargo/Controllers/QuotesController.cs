using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Cargo.Service.QuotesSrv;

namespace Cargo.Web.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class QuotesController : ControllerBase
    {
        private readonly IQuotesServices _quotesServices;
        private readonly ILogger<QuotesController> _logger;
        public QuotesController(IQuotesServices quotesServices, ILogger<QuotesController> logger)
        {
            _quotesServices = quotesServices;
            _logger=logger;
        }
        [HttpGet]
        public IActionResult GetRandomQuotes()
        {
            try
            {
                var result = _quotesServices.GetRandomQuotes();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex });
            }
        }
        [HttpGet]
        public IActionResult GetAllAuthor()
        {
            try
            {
                var result = _quotesServices.GetAllAuthor("albert-einstein", 30, "Author");
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex });
            }
        }
    }
}
