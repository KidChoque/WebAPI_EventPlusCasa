using webapi._4eventplus.manha.Domains;

namespace webapi._4eventplus.manha.Interfaces
{
    public interface ITiposEventoRepository
    {
        void Cadastrar(TiposEvento tiposEvento);
        List<TiposEvento> Listar();
        TiposEvento BuscarPorId(Guid id);
        void Deletar(Guid id);
        void Atualizar(Guid id, TiposEvento tiposEvento);

    }
}
