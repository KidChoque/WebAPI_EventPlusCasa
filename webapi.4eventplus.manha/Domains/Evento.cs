using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi._4eventplus.manha.Domains
{
    [Table(nameof(Evento))]
    public class Evento
    {
        [Key]
        public Guid IdEvento { get; set; } = Guid.NewGuid();

        [Column(TypeName ="DATE")]
        [Required(ErrorMessage = "Data do Evento obrigatória")]
        public DateTime DataEvento { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "Nome do Evento obrigatório")]
        public string? NomeEvento { get; set; }

        [Column(TypeName = "TEXT")]
        [Required(ErrorMessage = "Descrição do Evento obrigatória")]
        public string? Descricao { get; set; }

        //ref.tabela TiposEvento = FK
        [Required(ErrorMessage ="O tipo de evento é obrigatório")]
        public Guid IdTipoEvento { get; set; }

        [ForeignKey(nameof(IdTipoEvento))]
        public TiposEvento? TiposEvento { get; set; }

        //ref.tabela Instituicao
        public Guid IdInstituicao { get; set; }


        [ForeignKey("IdInstituicao")]
        public Instituicao? Instituicao { get; set; }


    }
}
