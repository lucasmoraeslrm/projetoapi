using Microsoft.EntityFrameworkCore;
using WebAPI.Model;

namespace WebAPI.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        { 
            
        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produto>().Property(p => p.Nome).HasMaxLength(80);

            modelBuilder.Entity<Produto>().
                HasData(
                new Produto
                {
                    Id = 1,
                    Nome = "Smartphone",
                    Preco = 2000,
                    QntEstoque = 50,
                    FK_CategoriaId = 1
                });

            modelBuilder.Entity<Categoria>().
                HasData(
                new Categoria
                {
                    CategoriasId = 1,
                    Nome = "Eletrônicos"
                });

            modelBuilder.Entity<Categoria>()
                .HasMany(c => c.Produtos)
                .WithOne(p => p.Categorias)
                .HasForeignKey(p => p.FK_CategoriaId);

            base.OnModelCreating(modelBuilder);
        }

    }
}
