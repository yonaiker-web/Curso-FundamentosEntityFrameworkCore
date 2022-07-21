using Microsoft.EntityFrameworkCore;

namespace FEF
{
    public class TasksContext: DbContext
    {
        //agregamos las colecciones que representan las tablas en la base de datos
        public DbSet<Category> Categorys { get; set; }
        public DbSet<Task> Tasks { get; set; }

        public TasksContext(DbContextOptions<TasksContext> options) : base(options) {}


        //reescribimos en modelo de la base de datos con sus restricciones
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(c => 
            {
                c.ToTable("Categoria");
                c.HasKey(c => c.CategoryId);
                c.Property(c => c.Name).IsRequired().HasMaxLength(150);
                c.Property(c => c.Description);
            });

            modelBuilder.Entity<Task>(t => 
            {
                t.ToTable("Tarea");
                t.HasKey(t => t.TaskId);
                t.HasOne(t => t.Category).WithMany(t => t.Task).HasForeignKey(t => t.CategoryId);
                t.Property(t => t.Title).IsRequired().HasMaxLength(200);
                t.Property(t => t.Description);
                t.Property(t => t.PriorityTask);
                t.Property(t => t.Creation);
                t.Ignore(t => t.Resumen);
            });
        }
    }
}