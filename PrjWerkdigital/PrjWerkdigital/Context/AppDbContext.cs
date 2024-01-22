using Microsoft.EntityFrameworkCore;
using PrjWerkdigital.Models;

namespace PrjWerkdigital.Context
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        public DbSet<UserModel>? Users { get; set; }
        public DbSet<TaskModel>? Tasks { get; set; }


        protected override void OnModelCreating(ModelBuilder mb)
        {
            //mb.Entity<TaskModel>().HasNoKey(m => m.TaskId);
            //base.OnModelCreating(mb);

            //mb
            //.Entity<TaskModel>(builder =>
            //{
            //    builder.HasNoKey();
            //    builder.ToTable("Tasks");
            //});

            // mb.Entity<TaskModel>()
            //.HasOne(e => e.UserId)
            //.WithMany(e => e.)
            //.HasForeignKey(e => e.TaskId)
            //.IsRequired();


            // modelBuilder
            //.Entity<TaskModel>(builder =>
            //{
            //    builder.HasNoKey();
            //    builder.ToTable("Tasks");
            //});
            // base.OnModelCreating(modelBuilder);

            //Task
            mb.Entity<TaskModel>().HasKey(c => c.TaskId);
            mb.Entity<TaskModel>().Property(c => c.Name).HasMaxLength(100).IsRequired();
            mb.Entity<TaskModel>().Property(c => c.Date_Begin).HasMaxLength(100).IsRequired();
            mb.Entity<TaskModel>().Property(c => c.Date_End).HasMaxLength(100).IsRequired();

            //User
            mb.Entity<UserModel>().HasKey(c => c.Id);
            mb.Entity<UserModel>().Property(c => c.Email).HasMaxLength(100).IsRequired();
            mb.Entity<UserModel>().Property(c => c.Password).HasMaxLength(100).IsRequired();







            //Beziehung
            //mb.Entity<TaskModel>().HasOne<UserModel>(c => c.UserId).WithMany(p => p.Tasks).HasForeignKey(c => c.);

            //mb.Entity<TaskModel>().HasOne<UserModel>(c => c.u).WithMany(p => p.Tasks).HasForeignKey(c => c.

            mb.Entity<TaskModel>().HasOne<UserModel>(c => c.User).WithMany(p => p.Tasks).HasForeignKey(c => c.UserId);

            //mb.Entity<Produto>().HasOne<Categoria>(c => c.Categoria).WithMany(p => p.Produtos).HasForeignKey(c => c.CategoriaId);



        }
    }
}
