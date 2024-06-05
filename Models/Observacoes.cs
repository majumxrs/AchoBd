using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Acho.Models
{
    [Table("Observacoes")]
    public class Observacoes
    {
        [Column("ObservacaoId")]
        [Display(Name = "Código do observação")]
        public int Id { get; set; }

        [Column("ObservacaoDescricao")]
        [Display(Name = "Observação")]
        public string ObservacaoDescricao { get; set; } = string.Empty;

        [Column("ObservacaoLocal")]
        [Display(Name = "Local")]
        public string ObservacaoLocal { get; set; } = string.Empty;

        [Column("ObservacaoData")]
        [Display(Name = "Data")]
        public DateTime ObservacaoData { get; set; } = DateTime.MinValue;

        [ForeignKey("AnimaisId")]
        public int AnimaisId { get; set; }
        public Animais? Animais { get; set; }

        [ForeignKey("UsuarioId")]
        public int UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }
    }
}
