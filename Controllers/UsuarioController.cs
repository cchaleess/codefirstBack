using CodeFirst.Context;
using CodeFirst.DBModels;
using CodeFirst.DTO;
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
    [Authorize]
    public class UsuarioController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IUsuarioService _usuarioService;

        static readonly string[] scopeRequiredByApi = new string[] { "User.Read" };

        public UsuarioController (IUsuarioService usuarioService, IConfiguration configuration)
        {
            _configuration = configuration;
            _usuarioService = usuarioService;
        }

        [HttpGet]
        public async Task<JsonResult> Get()
        {
           return new JsonResult(await _usuarioService.GetUSuariosList());            
        }

        [HttpPost]
        public async Task<JsonResult> Post(UsuarioCreatedDTO usuarioDTO)
        {
            return new JsonResult(await _usuarioService.SaveUsuarioDb(usuarioDTO));
        }

        [HttpPut("{id}")]
        public async Task<JsonResult> Put(UsuarioUpdateDTO usuarioDTO, int id)
        {
            return new JsonResult(await _usuarioService.UpdateUsuarioDb(usuarioDTO,id));
        }

        [HttpDelete("{id}")]
        public async Task<JsonResult> Delete(int id)
        {
            return new JsonResult(await _usuarioService.DeleteUsuarioDb(id));
        }
    }
}
