using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhoneNumberMappingApi.Infrastructure.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneNumberMappingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhoneNumberMapperController : ControllerBase
    {
        private readonly IPhoneNumberService _phoneNumberService;

        public PhoneNumberMapperController(IPhoneNumberService phoneNumberService)
        {
            _phoneNumberService = phoneNumberService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync([Required] string phoneNumber, string prefix)
        {
            try
            {
                var correctPhoneNumber = _phoneNumberService.Map(prefix, phoneNumber);

                return Ok(correctPhoneNumber);
            }
            catch
            {
                return BadRequest("Incorrect phoneNumber");
            }
        }
    }
}
