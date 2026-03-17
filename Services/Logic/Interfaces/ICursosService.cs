using DataBase.Entitys;
using Models.Cursos;

namespace Services.Logic.Interfaces;

public interface ICursosService
{
    Task<List<Curso>> GetCursosAsync();
    Task<bool> CadastrarAsync(CursoViewModelInput cursoViewModelInput);
}