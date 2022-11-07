using FuncionesLinq.Models;
using Microsoft.EntityFrameworkCore;
namespace FuncionesLinq.Data
{
    public class FuncDBContext : DbContext
    {
        public FuncDBContext(DbContextOptions<FuncDBContext> options) :
            base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Alumno> Alumnos { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Inscritos> Inscritos { get; set; }

    }
}
