using System.Net;
using DataBase.Entitys;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.Cursos;
using Services.Logic.Interfaces;

namespace Cursos.API.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
[Authorize]
public class CursoController: ControllerBase
{
    private readonly ICursosService _cursosService;
    public CursoController(ICursosService cursosService)
    {
        _cursosService = cursosService;
    }
    [HttpPost("cadastrar")]
    [ProducesResponseType(typeof(bool), (int)HttpStatusCode.Created)]
    public async Task<IActionResult> Cadastrar(CursoViewModelInput cursoViewModelInput)
    {
        try
        {
            var result = await _cursosService.CadastrarAsync(cursoViewModelInput);
            return Created("", result);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("listar-cursos")]
    [ProducesResponseType(typeof(List<Curso>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Get()
    {
        try
        {
            var cursos = await _cursosService.GetCursosAsync();
            return Ok(cursos);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
}