using webapi._4eventplus.manha.Contexts;
using webapi._4eventplus.manha.Domains;
using webapi._4eventplus.manha.Interfaces;

namespace webapi._4eventplus.manha.Repositories
{
    public class TiposUsuarioRepository : ITiposUsuarioRepository
    {
        private readonly EventContext _eventContext;

        //PRECISA DO CONSTRUTOR PRA FUNCIONAR KKKKKK
        public TiposUsuarioRepository() 
        {
          _eventContext= new EventContext();
        }

        public void Atualizar(Guid id, TiposUsuario tiposUsuario)
        {
            TiposUsuario tipoBuscado = _eventContext.TiposUsuario.Find(id);

            if (tipoBuscado != null)
            {
                tipoBuscado.Titulo = tiposUsuario.Titulo;
            }

            _eventContext.TiposUsuario.Update(tipoBuscado!);

            _eventContext.SaveChanges();

        }

        public TiposUsuario BuscarPorId(Guid id)
        {
            TiposUsuario tipoBuscado = _eventContext.TiposUsuario.Find(id);

            return tipoBuscado;
        }

        public void Cadastrar(TiposUsuario tiposUsuario)
        {
            _eventContext.TiposUsuario.Add(tiposUsuario);

            _eventContext.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            //Método para encontrar o id antes de deletar o tipo do usuário
            TiposUsuario tipoBuscado = _eventContext.TiposUsuario.Find(id);

            _eventContext.TiposUsuario.Remove(tipoBuscado);

            _eventContext.SaveChanges();
        }

        public List<TiposUsuario> Listar()
        {

            return _eventContext.TiposUsuario.ToList();
            

        }
    }
}
