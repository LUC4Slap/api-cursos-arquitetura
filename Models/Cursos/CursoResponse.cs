namespace Models.Cursos;

public class CursoResponse
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public List<UsuarioResponse> Usuarios { get; set; }
}

public class UsuarioResponse
{
    public int Id { get; set; }
    public string Nome { get; set; }
}