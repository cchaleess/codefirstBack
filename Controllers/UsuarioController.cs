using CodeFirst.Context;
using CodeFirst.DBModels;
using CodeFirst.DTO;
using CodeFirst.Interfaces;
using CodeFirst.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFirst.Controllers
{
 
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class UsuarioController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IUsuarioService _usuarioService;
        private readonly IValidationException _validationException;
        static readonly string[] scopeRequiredByApi = new string[] { "User.Read" };

        public UsuarioController (IUsuarioService usuarioService, IConfiguration configuration, IValidationException validationException)
        {
            _configuration = configuration;
            _usuarioService = usuarioService;
            _validationException = validationException;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return _validationException.Validate("GET", await _usuarioService.GetUSuariosList(), Content(""));
        }

        [HttpPost]
        public async Task<ActionResult> Post(UsuarioCreatedDTO usuarioDTO)
        {
            return _validationException.Validate("POST", await _usuarioService.SaveUsuarioDb(usuarioDTO), Content(""));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(UsuarioUpdateDTO usuarioDTO)
        {
            return  _validationException.Validate("PUT", await _usuarioService.UpdateUsuarioDb(usuarioDTO), Content(""));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            return _validationException.Validate("DELETE",await _usuarioService.DeleteUsuarioDb(id), Content(""));
        }
    }
}
