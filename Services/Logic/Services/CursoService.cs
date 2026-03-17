using DataBase;
using DataBase.Entitys;
using Microsoft.EntityFrameworkCore;
using Models.Cursos;
using Services.Logic.Interfaces;

namespace Services.Logic.Services;

public class CursoService : ICursosService
{
    private readonly AppDbContext _context;
    public CursoService(AppDbContext context)
    {
        _context = context;
    }
    public async Task<List<CursoResponse>> GetCursosAsync()
    {
        try
        {
            var cursos = await _context.Cursos
                .Include(c => c.UsuarioCursos)
                .Select(c => new CursoResponse
                {
                    Id = c.Id,
                    Nome = c.Nome,
                    Usuarios = c.UsuarioCursos.Select(u => new UsuarioResponse
                    {
                        Id = u.UsuarioId,
                        Nome = u.Usuario.Nome
                    }).ToList()
                })
                .ToListAsync();

            return cursos;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task<bool> CadastrarAsync(CursoViewModelInput cursoViewModelInput)
    {
        try
        {
            var curso = new Curso();
            curso.Nome = cursoViewModelInput.Nome;
            curso.Descricao = cursoViewModelInput.Descricao;
            _context.Cursos.Add(curso);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
}