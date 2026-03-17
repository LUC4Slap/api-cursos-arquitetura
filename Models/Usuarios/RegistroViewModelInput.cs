using System.ComponentModel.DataAnnotations;

namespace Models.Usuarios;

public class RegistroViewModelInput
{
    [Required(ErrorMessage = "Login é obrigatório")]
    public string Login { get; set; } =  string.Empty;
    
    [Required(ErrorMessage = "Nome é obrigatório")]
    public string Nome { get; set; } =  string.Empty;

    [Required(ErrorMessage = "O E-mail é obrigatório")]
    public string Email { get; set; } =  string.Empty;
    
    [Required(ErrorMessage = "A senha é obrigatória")]
    public string Senha { get; set; } =  string.Empty;
}