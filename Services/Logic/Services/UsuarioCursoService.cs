using DataBase;
using DataBase.Entitys;
using Microsoft.EntityFrameworkCore;
using Services.Logic.Interfaces;

namespace Services.Logic.Services;

public class UsuarioCursoService : IUsuarioCursoService
{
    private readonly AppDbContext _context;
    public UsuarioCursoService(AppDbContext context)
    {
        _context = context;
    }
    public async Task<List<UsuarioCurso>> BuscarTodosOsCursosComUsuaios()
    {
        try
        {
            var usuario_cursos = await _context.UsuarioCursos.ToListAsync();
            return usuario_cursos;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task<bool> CadastrarUsuarioCurso(int cursoId, int usuarioId)
    {
        try
        {
            var usuarioCurso = new UsuarioCurso
            {
                CursoId = cursoId,
                UsuarioId = usuarioId
            };
            await _context.UsuarioCursos.AddAsync(usuarioCurso);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
}