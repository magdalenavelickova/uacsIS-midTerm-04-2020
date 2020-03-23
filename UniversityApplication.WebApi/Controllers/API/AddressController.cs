using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UniversityApplication.Data.DTOs;
using UniversityApplication.Service.Service;

namespace UniversityApplication.WebApi.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly ILogger<AddressController> _logger;
        private readonly IAddressService _service;

        public AddressController(ILogger<AddressController> logger, IAddressService service)
        {
            _logger = logger;
            _service = service;
        }

        // GET: api/Address
        [HttpGet]
        [Route("Get")]
        public IEnumerable<AddressDTO> Get()
        {
            return _service.GetAddresses();
        }

        // GET: api/Address/5
        [HttpGet]
        [Route("Get/{Id:int}")]
        public AddressDTO Get(int id)
        {
            return _service.GetAddress(id);
        }

        // POST: api/Address
        [HttpPost]
        [Route("Post")]
        public IActionResult Post([FromBody] AddressDTO address)
        {
            if (ModelState.IsValid)
            {
                var result = _service.SaveAddress(address);
                return Ok(result);
            }

            return BadRequest(ModelState);
        }

        // PUT: api/Address/5
        [HttpPut]
        [Route("Put/{id:int}")]
        public AddressDTO Put(int id, [FromBody] AddressDTO address)
        {
            return _service.PutPoints(id, address);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete]
        [Route("Delete/{id:int}")]
        public IActionResult Delete(int id)
        {
            var deleted = _service.DeleteAddress(id);
            if (deleted)
            {
                return Ok("Address successfully deleted");
            }

            return BadRequest("There isn't any address with that id");
        }
    }
}
