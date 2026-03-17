using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Common.EncriptyPass.Logic.Interfaces;
using DataBase;
using DataBase.Entitys;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Models.Usuarios;
using Services.Logic.Interfaces;

namespace Services.Logic.Services;

public class UsuarioService : IUsuarioService
{
    private readonly IConfiguration _config;
    private readonly AppDbContext _context;
    private readonly IIncryptService  _incryptService;

    public UsuarioService(IConfiguration config, AppDbContext context, IIncryptService incryptService)
    {
        _config = config;
        _context = context;
        _incryptService = incryptService;
    }
    public async Task<LoginResponse> Login(LoginViewModelInput loginViewModel)
    {
        try
        {
            var usuario = _context.Usuarios.Where(x => x.Login == loginViewModel.Login).FirstOrDefault();
            
            if(usuario == null)
                return new LoginResponse { Sucesso = false, Erros = "Usuario ou senha incorretos" };
            
            if(!_incryptService.Verify(loginViewModel.Senha, usuario.Senha))
                return new LoginResponse { Sucesso = false, Erros = "Usuario ou senha incorretos" };
            
            var secret = Encoding.UTF8.GetBytes(_config["JwtConfiguration:Secret"]);
            var symetricSecurityKey = new SymmetricSecurityKey(secret);
            var securityTokenDescriptot = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
                    new Claim(ClaimTypes.NameIdentifier, loginViewModel.Login),
                    new Claim(ClaimTypes.Name, loginViewModel.Senha)
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(symetricSecurityKey, SecurityAlgorithms.HmacSha256)
            };
            var jwtSecurityTokenHendler = new JwtSecurityTokenHandler();
            var tokeGenerated =  jwtSecurityTokenHendler.CreateToken(securityTokenDescriptot);
            var token = jwtSecurityTokenHendler.WriteToken(tokeGenerated);
            return new LoginResponse { Sucesso = true, Token = token };
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task<bool> CriarUsuario(RegistroViewModelInput registroViewModel)
    {
        try
        {
            var usuario = new Usuario
            {
                Nome = registroViewModel.Nome,
                Login = registroViewModel.Login,
                Email = registroViewModel.Email,
                Senha = _incryptService.Encrypt(registroViewModel.Senha)
            };

            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            throw new Exception(e.ToString());
        }
    }
}