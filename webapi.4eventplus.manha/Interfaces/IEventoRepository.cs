using webapi._4eventplus.manha.Domains;

namespace webapi._4eventplus.manha.Interfaces
{
    public interface IEventoRepository
    {
        void Cadastrar(Evento evento);
        List<Evento> Listar();
        Evento BuscarPorId(Guid id);
        void Deletar(Guid id);
        void Atualizar(Guid id, Evento evento);
    }
}
