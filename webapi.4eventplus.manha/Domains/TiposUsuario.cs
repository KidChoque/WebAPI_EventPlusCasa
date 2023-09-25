using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi._4eventplus.manha.Domains
{
    [Table(nameof(TiposUsuario))]
    public class TiposUsuario
    {
        [Key]
        public Guid IdTipoUsuario { get; set; }= Guid.NewGuid();

       [Column(TypeName ="VARCHAR(100)")]
       [Required(ErrorMessage = "Titulo Obrigatório")]
        public string? Titulo { get; set; }
    }
}
