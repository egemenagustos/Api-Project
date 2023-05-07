using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IServieceService _servieceService;

        public ServiceController(IServieceService servieceService)
        {
            _servieceService = servieceService;
        }

        [HttpGet]
        public IActionResult ServiceList()
        {
            var values = _servieceService.TGetList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult AddService(Service service)
        {
            _servieceService.TInsert(service);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteService(int id)
        {
            var values = _servieceService.TGetById(id);
            _servieceService.TDelete(values);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateService(Service service)
        {
            _servieceService.TUpdate(service);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetService(int id)
        {
            var values = _servieceService.TGetById(id);
            return Ok(values);
        }
    }
}
