using System.Net;
using Cursos.API.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Logic.Interfaces;

namespace Cursos.API.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
[Authorize]
public class UsuarioCursoController : ControllerBase
{
    private readonly IUsuarioCursoService _usuarioCursoService;
    public UsuarioCursoController(IUsuarioCursoService  usuarioCursoService)
    {
        _usuarioCursoService = usuarioCursoService;
    }

    [HttpPost("cadastro-vinculo-usuario-curso")]
    [ProducesResponseType(typeof(bool), (int)HttpStatusCode.Created)]
    [ValidacaoModelStateCustomizado]
    public async Task<IActionResult> CadastrarUsuarioCurso(int cursoId, int usuarioId)
    {
        try
        {
            var result = await _usuarioCursoService.CadastrarUsuarioCurso(cursoId, usuarioId);
            return Ok(result);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}