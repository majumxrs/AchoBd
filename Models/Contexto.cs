using Microsoft.EntityFrameworkCore;
using Acho.Models;

namespace Acho.Models
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {

        }

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Animais> Animal { get; set; }
        public DbSet<Acho.Models.Observacoes> Observacoes { get; set; } = default!;
        //public DbSet<Observacoes> Observacao { get; set; }
    }
}
