using Microsoft.EntityFrameworkCore;

namespace RSistemasCRUDCompleto.Models
{
    public class GrupoProdutosContext: DbContext
    {
        public DbSet<GrupoDeProdutos> grupoDeProdutos { get; set; }
        public GrupoProdutosContext(DbContextOptions<GrupoProdutosContext> options) : base(options)
        {
        }
    }
}
