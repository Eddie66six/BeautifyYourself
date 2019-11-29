using Auth.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace Auth.Repository
{
    public class Context : DbContext
    {
        //primeira vez
        //Add-Migration InitialCreate -> Update-Database
        //atualizar
        //Add-Migration AddProductReviews -> Update-Database
        //remover
        //Remove-Migration
        //reverter
        //Update-Database LastGoodMigration
        public Context()
        {

        }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Ignore<Pessoa>();
            //modelBuilder.Ignore<Funcionario>();
            //N:N
            //modelBuilder.Entity<ConvenioCredenciado>()
            //    .HasKey(t => new { t.IdMedico, t.IdConveio });
            //modelBuilder.Entity<ColaboradorPermissao>()
            //    .HasKey(t => new { t.IdColaborador, t.IdPermissao });

            //geral
            modelBuilder.ApplyConfiguration(new UserMap());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // define the database to use
            //optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=EasyControlDb;Integrated Security=true");
        }
    }
}
