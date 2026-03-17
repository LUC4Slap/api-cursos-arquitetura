using Models.Usuarios;

namespace Services.Logic.Interfaces;

public interface IUsuarioService
{
    Task<LoginResponse> Login(LoginViewModelInput loginViewModel);
    Task<bool> CriarUsuario(RegistroViewModelInput registroViewModel);
}