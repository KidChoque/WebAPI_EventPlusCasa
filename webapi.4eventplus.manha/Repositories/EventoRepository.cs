using webapi._4eventplus.manha.Contexts;
using webapi._4eventplus.manha.Domains;
using webapi._4eventplus.manha.Interfaces;

namespace webapi._4eventplus.manha.Repositories
{
    public class EventoRepository : IEventoRepository
    {
        private readonly EventContext _eventContext;

        //PRECISA DO CONSTRUTOR PRA FUNCIONAR KKKKKK
        public EventoRepository()
        {
            _eventContext = new EventContext();
        }
        public void Atualizar(Guid id, Evento evento)
        {
            Evento eventoBuscado = _eventContext.Evento.Find(id);

            if (eventoBuscado != null)
            {
                eventoBuscado.NomeEvento = evento.NomeEvento;
                eventoBuscado.DataEvento = evento.DataEvento;
                eventoBuscado.Descricao = evento.Descricao;
                eventoBuscado.IdTipoEvento = evento.IdTipoEvento;
                eventoBuscado.TiposEvento= evento.TiposEvento;
            }

            _eventContext.Evento.Update(eventoBuscado);

            _eventContext.SaveChanges();
        }

        public Evento BuscarPorId(Guid id)
        {
            Evento eventoBuscado = _eventContext.Evento.
                Select(u => new Evento
                {
                    IdEvento = u.IdEvento,
                    NomeEvento = u.NomeEvento,
                    Descricao = u.Descricao,
                    DataEvento = u.DataEvento,
                    TiposEvento = new TiposEvento
                    {
                        IdTipoEvento = u.IdTipoEvento,
                        Titulo = u.TiposEvento.Titulo
                    }

                }).FirstOrDefault(u=> u.IdEvento == id)!;

            return eventoBuscado;
        }

        public void Cadastrar(Evento evento)
        {
            _eventContext.Evento.Add(evento);

            _eventContext.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            Evento eventoBuscado = _eventContext.Evento.Find(id);

            _eventContext.Evento.Remove(eventoBuscado);

            _eventContext.SaveChanges();
        }

        public List<Evento> Listar()
        {
           return _eventContext.Evento.
                Select(u => new Evento
                {
                   IdEvento = u.IdEvento,
                   NomeEvento= u.NomeEvento,
                   Descricao= u.Descricao,
                   DataEvento= u.DataEvento,
                   TiposEvento = new TiposEvento
                   {
                       IdTipoEvento= u.IdTipoEvento,
                       Titulo= u.TiposEvento.Titulo
                   },
                   Instituicao = new Instituicao
                   {
                       IdIsntituicao = u.IdInstituicao,
                       Endereco = u.Instituicao.Endereco,
                       NomeFantasia = u.Instituicao.NomeFantasia
                   }

                }).ToList();



        }
    }
}
