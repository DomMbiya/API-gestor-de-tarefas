using Gestor_de_tarefas.Data.Map;
using Gestor_de_tarefas.Models;
using Microsoft.EntityFrameworkCore;

namespace Gestor_de_tarefas.Data
{
    public class GestorTarefasDbContext: DbContext
    {
        public GestorTarefasDbContext(DbContextOptions<GestorTarefasDbContext> options) : base(options)
        {

        }
        public DbSet<UsuarioModel> Usuarios { get; set; }
        public DbSet<TarefaModel> Tarefas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new TarefaMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
