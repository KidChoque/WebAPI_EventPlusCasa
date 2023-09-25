using Microsoft.EntityFrameworkCore;
using webapi._4eventplus.manha.Domains;

namespace webapi._4eventplus.manha.Contexts
{
    public class EventContext : DbContext
    {
        public DbSet<TiposUsuario> TiposUsuario { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<TiposEvento> TiposEvento { get; set; }
        public DbSet<Evento> Evento { get; set; }
        public DbSet<ComentariosEvento> ComentariosEvento { get; set; }
        public DbSet<Instituicao> Instituicao { get; set; }
        public DbSet<PresencaEvento> PresencaEvento { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-TLP19HH\\SQLEXPRESS; Database=Event+_CodeFirst_Manha_Lucas;Integrated Security=True; TrustServerCertificate=true;");
            base.OnConfiguring(optionsBuilder);
        }

    }
}
