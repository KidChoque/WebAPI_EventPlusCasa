using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi._4eventplus.manha.Domains
{
    [Table(nameof(Instituicao))]
    [Index(nameof(CNPJ),IsUnique =true)]
    public class Instituicao
    {
        [Key]
        public Guid IdIsntituicao { get; set; } = Guid.NewGuid();

        [Column(TypeName ="CHAR(14)")]
        [Required(ErrorMessage = "CNPJ de instituicao obrigatória")]
        [StringLength(14)]
        public string? CNPJ { get; set; }

        [Column(TypeName = "VARCHAR(150)")]
        [Required(ErrorMessage = " Endereco da instituicao obrigatório")]
        public string? Endereco { get; set; }


        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = " Nome Fantasia da instituicao obrigatório")]
        public string? NomeFantasia { get; set; }
    }
}
