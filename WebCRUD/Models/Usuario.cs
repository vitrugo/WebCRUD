using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebCRUD.Models
{
    public class Usuario
    {
        [Column("Id")]
        [Display(Name = "Id")]
        [Key]
        public int Id { get; set; }

        [Column("Nome")]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Column("CPF")]
        [Display(Name = "CPF")]
        public string CPF { get; set; }

        [Column("Telefone")]
        [Display(Name = "Telefone")]
        public int Telefone { get; set; }

        [Column("Email")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Column("CEP")]
        [Display(Name = "CEP")]
        public int CEP { get; set; }

        [Column("Endereco")]
        [Display(Name = "Endereco")]
        public string Endereco { get; set; }

        [Column("Documento_RG_PDF")]
        [Display(Name = "Documento_RG_PDF")]
        public string Documento_RG_PDF { get; set; }

        [Column("Grupo_Usuario_ID")]
        [Display(Name = "Grupo_Usuario_ID")]
        [ForeignKey("GrupoUsuario")]
        public int Grupo_Usuario_ID { get; set; }

        public GrupoUsuario? GrupoUsuario { get; set; }

    }
}
