using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi._4eventplus.manha.Domains;
using webapi._4eventplus.manha.Interfaces;
using webapi._4eventplus.manha.Repositories;

namespace webapi._4eventplus.manha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class UsuarioController : ControllerBase
    {

            IUsuarioRepository _usuarioRepository;
            public UsuarioController()
            {
                _usuarioRepository = new UsuarioRepository();
            }

            [HttpPost]
            public IActionResult Post(Usuario usuario)
            {
                try
                {
                    _usuarioRepository.Cadastrar(usuario);

                    return StatusCode(201);
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
            }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            Usuario usuarioBuscado = new Usuario();

            try
            {
                return Ok(_usuarioRepository.BuscarPorId(id));
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }


        }

    }
}
