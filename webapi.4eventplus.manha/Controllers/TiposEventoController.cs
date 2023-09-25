using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi._4eventplus.manha.Domains;
using webapi._4eventplus.manha.Interfaces;
using webapi._4eventplus.manha.Repositories;

namespace webapi._4eventplus.manha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TiposEventoController : ControllerBase
    {
        private readonly ITiposEventoRepository _tiposEventoRepository;

        public TiposEventoController()
        {
            _tiposEventoRepository = new TIposEventoRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_tiposEventoRepository.Listar());
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            };
        }

        [HttpPost]
        public IActionResult Post(TiposEvento tiposEvento)
        {
            _tiposEventoRepository.Cadastrar(tiposEvento);
            return Ok(201);

        }

        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _tiposEventoRepository.Deletar(id);
                return NoContent();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
           
        }

        [HttpPut]
        public IActionResult Update(Guid id, TiposEvento tiposEvento)
        {
            try
            {
                _tiposEventoRepository.Atualizar(id, tiposEvento);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id) 
        {

            return Ok(_tiposEventoRepository.BuscarPorId(id));
        }

    }
}
