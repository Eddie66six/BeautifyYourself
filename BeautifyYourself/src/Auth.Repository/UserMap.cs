using Auth.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Auth.Repository
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            // Override nvarchar(max) with nvarchar(15)
            builder.HasKey(u => u.UserId);
            builder.Property(u => u.Name).HasMaxLength(50);

            //builder.HasMany(p => p.Pacientes)
            //    .WithOne(b => b.Convenio);

            //builder.HasMany(p => p.MedicosCredenciados)
            //    .WithOne(b => b.Convenio);

            // Make the default table name of AspNetUsers to Users
            //builder.ToTable("Users");
        }
    }
}
