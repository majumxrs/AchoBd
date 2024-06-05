using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Acho.Models
{
    [Table("Animais")]
    public class Animais
    {
        [Column("AnimaisId")]
        [Display(Name = "Código do Animal")]
        public int AnimaisId { get; set; }

        [Column("AnimalNome")]
        [Display(Name = "Nome")]
        public string AnimalNome { get; set; } = string.Empty;

        [Column("AnimalRaca")]
        [Display(Name = "Raça")]
        public string AnimalRaca { get; set; } = string.Empty;

        [Column("AnimalTipo")]
        [Display(Name = "Tipo do Animal")]
        public string AnimalTipo { get; set; } = string.Empty;

        [Column("AnimalCor")]
        [Display(Name = "Cor")]
        public string AnimalCor { get; set; } = string.Empty;

        [Column("AnimalSexo")]
        [Display(Name = "Sexo")]
        public string AnimalSexo { get; set; } = string.Empty;

        [Column("AnimalObservacao")]
        [Display(Name = "Observação")]
        public string AnimalObservacao { get; set; } = string.Empty;

        [Column("AnimalFoto")]
        [Display(Name = "Foto")]
        public string AnimalFoto { get; set; } = string.Empty;

        [Column("AnimalDataDesaparecimento")]
        [Display(Name = "Data de Desaparecimento")]
        public DateTime AnimalData { get; set; } = DateTime.MinValue;

        [Column("AnimalDataEncontro")]
        [Display(Name = "Data de Encontro")]
        public DateTime? AnimalDataEncontro { get; set; } = DateTime.MinValue;

        [Column("AnimalStatus")]
        [Display(Name = "Status")]
        public byte AnimalStatus { get; set; } = byte.MinValue;

        [ForeignKey("usuarioId")]
        public int usuarioId { get; set; }
        public Usuario? Usuario { get; set; }
    }
}
