using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StudioSintoniaPreview.Entities;
using StudioSintoniaPreview.Models;

namespace StudioSintoniaPreview.Data
{
    public class BancoContext : IdentityDbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {

        }
        public DbSet<PostModel> Posts { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<UsuarioLogin> UsuarioLogins { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UsuarioLogin>().HasData(
                new UsuarioLogin
                {
                    UsuarioLoginId = 1,
                    UsuarioNome = "Lucas Avanci",
                    UsuarioEmail = "lucasavanzzi1223@gmail.com",
                    Celular = 11977039750

                });
        }
    }
}
