namespace DataBase.Entitys;

public class Curso
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public ICollection<UsuarioCurso> UsuarioCursos { get; set; }
}