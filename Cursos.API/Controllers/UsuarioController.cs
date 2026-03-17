using System.Net;
using Cursos.API.Filters;
using Microsoft.AspNetCore.Mvc;
using Models.Usuarios;
using Services.Logic.Interfaces;

namespace Cursos.API.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class UsuarioController : ControllerBase
{
    private readonly IUsuarioService _usuarioService;
    public UsuarioController(IUsuarioService usuarioService)
    {
        _usuarioService = usuarioService;
    }
    
    [HttpPost("login")]
    [ProducesResponseType(typeof(LoginResponse), (int)HttpStatusCode.OK)]
    [ValidacaoModelStateCustomizado]
    public async Task<IActionResult> Logar([FromBody] LoginViewModelInput  loginViewModel)
    {
        try
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            
            var loginResult = await _usuarioService.Login(loginViewModel);
            
            if(!loginResult.Sucesso)
                return BadRequest(loginResult);
            
            return Ok(loginResult);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost("registro")]
    [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(List<string>), (int)HttpStatusCode.InternalServerError)]
    public async Task<IActionResult> Registrar([FromBody] RegistroViewModelInput registroViewModel)
    {
        try
        {
            var result = await _usuarioService.CriarUsuario(registroViewModel);
            return Created("", result);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}