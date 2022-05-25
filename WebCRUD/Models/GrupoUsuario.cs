using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebCRUD.Models
{
    [Table("GrupoUsuario")]
    public class GrupoUsuario
    {
        [Column("Id")]
        [Display(Name="Id")]
        [Key]
        public int Id { get; set; }

        [Column("Descricao")]
        [Display(Name = "Descricao")]
        public string Descricao { get; set; }

        public IList<Usuario>? Usuarios { get; set; }
    }
}
