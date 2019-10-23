using Microsoft.EntityFrameworkCore;
using TypeFitess.Models;

namespace TypeFitess
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Produto>().HasKey(t => t.Id);
            modelBuilder.Entity<Produto>().Property(p => p.Preco).HasColumnType("decimal(10,2)");

            modelBuilder.Entity<Cadastro>().HasKey(t => t.Id);
            modelBuilder.Entity<Cadastro>().HasOne(t => t.Pedido).WithOne(t => t.Cadastro).HasForeignKey<Pedido>(t => t.CadastroId);

            modelBuilder.Entity<Pedido>().HasKey(t => t.Id);
            modelBuilder.Entity<Pedido>().HasMany(t => t.Itens).WithOne(t => t.Pedido);
            modelBuilder.Entity<Pedido>().HasOne(t => t.Cadastro).WithOne(t => t.Pedido);

            modelBuilder.Entity<ItemPedido>().HasKey(t => t.Id);
            modelBuilder.Entity<ItemPedido>().HasOne(t => t.Pedido);
            modelBuilder.Entity<ItemPedido>().HasOne(t => t.Produto);
            modelBuilder.Entity<ItemPedido>().Property(p => p.Preco).HasColumnType("decimal(10,2)");

            modelBuilder.Entity<Chat>().HasKey(t => t.Id);
            modelBuilder.Entity<Chat>().HasOne(t => t.UserRemetente).WithMany(t => t.ChatRemetente).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Chat>().HasOne(t => t.UserDestinatario).WithMany(t => t.ChatDestinatario).OnDelete(DeleteBehavior.Restrict);

        }
    }
}
