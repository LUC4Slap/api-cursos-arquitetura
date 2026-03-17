using System.ComponentModel.DataAnnotations;

namespace Models.Usuarios;

public class LoginViewModelInput
{
    [Required(ErrorMessage = "Login é obrigatório")]
    public string Login { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "A senha é obrigatória")]
    public string Senha { get; set; }  = string.Empty;
}