﻿using Microsoft.AspNetCore.Mvc;
using UsuariosAPI.Data.Dtos;

namespace UsuariosAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CadastroController : ControllerBase
    {


        [HttpPost]
        public IActionResult CadastroUsuario(CreateUsuarioDto createDto)
        {
            return Ok();
        }
    }
}
