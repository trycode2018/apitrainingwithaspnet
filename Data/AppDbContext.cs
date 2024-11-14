using LivroApi.Models;
using Microsoft.EntityFrameworkCore;

namespace LivroApi.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options):DbContext(options)
    {
        public DbSet<LivroModel> Livros { get; set; }
        public DbSet<AutorModel> Autores { get; set; } 
    }
}
