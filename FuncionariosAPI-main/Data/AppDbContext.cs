using FuncionariosAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FuncionariosAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Funcionario> Funcionarios { get; set; }
    }
}
