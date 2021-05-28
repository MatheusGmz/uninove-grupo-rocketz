using Login.Application.Interfaces;
using Login.Application.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Login.Api.Controllers
{
    [ApiController]
    [Route("register")]
    public class ClientController : ControllerBase
    {
        private readonly IClientServices _clientServices;

        public ClientController(IClientServices accountServices)
        {
            _clientServices = accountServices;
        }
        [HttpGet]
        public IActionResult GetClientByCpf(string cpf)
        {
            try
            {
                var id = _clientServices.GetClientByCpf(cpf);
                if (id == null)
                {
                    return NotFound();
                }
                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }
        [HttpPost]
        public IActionResult RegisterClient(ClientViewModel clientViewModel)
        {
            try
            {
                var sucessCheck = _clientServices.RegisterClient(clientViewModel);
                return Ok(sucessCheck);
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpDelete]
        public IActionResult DeleteClient(string cpf)
        {
            try
            {
                var sucessCheck = _clientServices.DeleteClientByCpf(cpf);
                return Ok(sucessCheck);
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpPut]
        public IActionResult UpdateClient(ClientViewModel accountViewModel)
        {
            try
            {
                var successCheck = _clientServices.UpdateClient(accountViewModel);
                if(successCheck != null)
                {
                    return Ok(successCheck);
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
