using LojaVirtual.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LojaVirtual.Infra.Data.EF
{
    public class LojaVirtualContext : DbContext
    {
        public DbSet<Boletin> Boletins { get; set; } 
        public DbSet<Carrinho>  Carrinhos { get; set; }
        public DbSet<Categoria>  Categorias { get; set; }
        public DbSet<Cliente>  Clientes { get; set; }
        public DbSet<Comentario> Comentarios { get; set; } 
        public DbSet<Cupom> Cupoms { get; set; } 
        public DbSet<CupomCategoria> CupomCategorias { get; set; } 
        public DbSet<Desconto> Descontos { get; set; }
        public DbSet<Endereco> Enderecos { get; set; } 
        public DbSet<Foto> Fotos { get; set; } 
        public DbSet<ListaDesejo> ListaDesejos { get; set; } 
        public DbSet<Pedido> Pedidos { get; set; } 
        public DbSet<PedidoItem> PedidoItems { get; set; } 
        public DbSet<Produto> Produtos { get; set; } 
        public DbSet<ProdutoTag> ProdutoTags { get; set; } 
        public DbSet<Tag> Tags { get; set; } 
        public DbSet<Usuario> Usuarios { get; set; } 

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string connetionString = "server=192.168.0.100;uid=root;pwd=Ab134679;database=loja-virtual";
                optionsBuilder.UseMySql(connetionString, ServerVersion.AutoDetect(connetionString));
            }
        }
               
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Cliente>()
            //    .HasOne(x => x.EnderecoEntrega)
            //    .WithMany(x => x.Clientes)
        }
    }
}
