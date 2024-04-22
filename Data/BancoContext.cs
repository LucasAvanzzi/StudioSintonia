using Microsoft.EntityFrameworkCore;
using StudioSintoniaPreview.Models;

namespace StudioSintoniaPreview.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {

        }
        public DbSet<UsuarioModel> Usuarios { get; set; }
        public DbSet<PostModel> Posts { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }
        public DbSet<ProfissaoModel> ProfissaoModels { get; set; }
        public DbSet<Tag> Tags { get; set; }
    }
}
