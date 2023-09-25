using webapi._4eventplus.manha.Domains;

namespace webapi._4eventplus.manha.Interfaces
{
    public interface IUsuarioRepository
    {
        void Cadastrar(Usuario usuario);

        Usuario BuscarPorId(Guid id);

        Usuario BuscarPorEMailSenha(string email, string senha);
    }
}
