namespace DataBase.Entitys;

public class Usuario
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Login { get; set; }
    public string Senha { get; set; }
    public string Email { get; set; }
    public ICollection<UsuarioCurso> UsuarioCursos { get; set; }

}