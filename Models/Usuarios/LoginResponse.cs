namespace Models.Usuarios;

public class LoginResponse
{
    public string? Token { get; set; }
    public bool Sucesso { get; set; }
    public string? Erros { get; set; }
}