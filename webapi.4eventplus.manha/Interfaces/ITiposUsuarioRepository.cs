using webapi._4eventplus.manha.Domains;

namespace webapi._4eventplus.manha.Interfaces
{
    public interface ITiposUsuarioRepository
    {
        void Cadastrar(TiposUsuario tiposUsuario);

        void Deletar(Guid id);

        List<TiposUsuario> Listar();

        TiposUsuario BuscarPorId(Guid id);

        void Atualizar(Guid id, TiposUsuario tiposUsuario);
    }
}
