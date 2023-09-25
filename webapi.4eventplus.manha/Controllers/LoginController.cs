using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using webapi._4eventplus.manha.Domains;
using webapi._4eventplus.manha.Interfaces;
using webapi._4eventplus.manha.Repositories;
using webapi._4eventplus.manha.ViewModels;

namespace webapi._4eventplus.manha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public LoginController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel usuario)
        {
            Usuario usuarioLogado = _usuarioRepository.BuscarPorEMailSenha(usuario.Email, usuario.Senha);

            if (usuarioLogado == null)
            {
                return NotFound("Email ou senha inválidos!");
            }
            var claims = new[]
            {
                  new Claim(JwtRegisteredClaimNames.Email, usuarioLogado.Email!),
                  new Claim(JwtRegisteredClaimNames.Name,usuarioLogado.Nome),
                  new Claim(JwtRegisteredClaimNames.Jti,usuarioLogado.IdUsuario.ToString()),
                  new Claim(JwtRegisteredClaimNames.Jti,usuarioLogado.TiposUsuario.Titulo!),

      
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("Event+-chave-autenticacao-webapi-dev"));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken
            (
                issuer: "webapi._4eventplus.manha",
                audience: "webapi._4eventplus.manha",
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds
            );

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token)
            });
        }
        //    public IActionResult Login(LoginViewModel usuario)
        //    {

        //        LoginViewModel usuario = _usuarioRepository.BuscarPorEMailSenha();

        //        if (usuario == null)
        //        {
        //            return NotFound("Email ou senha inválidos!");
        //        }

        //        var claims = new[]
        //        {
        //            new Claim(JwtRegisteredClaimNames.Email, usuario.Email),
        //            new Claim(JwtRegisteredClaimNames.Jti, usuario.IdUsuario.ToString()),
        //            new Claim(ClaimTypes.Role, usuario.IdTipoUsuario.ToString())

        //        };

        //        var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("inlock-chave-autenticacao-webapi-dev"));

        //        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        //        var token = new JwtSecurityToken
        //        (
        //            issuer: "webapi.inlock",
        //            audience: "webapi.inlock",
        //            claims: claims,
        //            expires: DateTime.Now.AddMinutes(30),
        //            signingCredentials: creds
        //        );

        //        return Ok(new
        //        {
        //            token = new JwtSecurityTokenHandler().WriteToken(token)
        //        });
        //    }
        //}

    }
}
