using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RegisterCompanyAndAuth.Models;
using RegisterCompanyAndAuth.Services.Interfaces;

namespace RegisterCompanyAndAuth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly IRegisterService _service;

        public RegisterController(IRegisterService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Users user)
        {
            try
            {
                user = await _service.Register(user);

                if(user == null)
                {
                    return BadRequest("Problemas ao salvar Usuário");
                }

                return Ok(user);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

    }
}