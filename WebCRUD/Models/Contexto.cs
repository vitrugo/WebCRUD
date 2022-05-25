using Microsoft.EntityFrameworkCore;

namespace WebCRUD.Models
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {

        }

        public DbSet<GrupoUsuario> Produto { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }
    }
}
