using DataBase.Entitys;

namespace Services.Logic.Interfaces;

public interface IUsuarioCursoService
{
    Task<List<UsuarioCurso>> BuscarTodosOsCursosComUsuaios();
    Task<bool> CadastrarUsuarioCurso(int cursoId, int usuarioId);
}