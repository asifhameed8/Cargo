using Cargo.Controllers;
using Cargo.Service.QuotesSrv;
using Cargo.Service.ShipperSrv;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cargo.Web.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ShipperController : ControllerBase
    {
        private readonly IShipperService _shipperServices;
        private readonly ILogger<ShipperController> _logger;
        public ShipperController(IShipperService shipperServices, ILogger<ShipperController> logger)
        {
            _shipperServices = shipperServices;
            _logger = logger;
        }
        [HttpGet]
        public ActionResult GetAllShipper()
        {
            try
            {
                var result = _shipperServices.GetAllShipper();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex });
            }
        }

        [HttpGet]
        [Route("{shipperId}")]
        public ActionResult GetShipperDetailsByShipperId(int shipperId)
        {
            try
            {
                var result = _shipperServices.GetShipperDetails(shipperId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex });
            }
        }
    }
}
