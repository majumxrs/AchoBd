using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Acho.Models
{
    [Table("Usuario")]
    public class Usuario
    {
        [Column("UsuarioId")]
        [Display(Name = "Código do Usuario")]
        public int Id { get; set; }

        [Column("UsuarioNome")]
        [Display(Name = "Nome")]
        public string UsuarioNome { get; set; } = string.Empty;

        [Column("UsuarioTelefone")]
        [Display(Name = "Telefone")]
        public string UsuarioTelefone { get; set; } = string.Empty;

        [Column("UsuarioEmail")]
        [Display(Name = "Email")]
        public string UsuarioEmail { get; set; } = string.Empty;

        [Column("UsuarioSenha")]
        [Display(Name = "Senha")]
        public string UsuarioSenha { get; set; } = string.Empty;
    }
}
