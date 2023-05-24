using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TesteComercio.Domain.Entities.Launchs;

namespace TesteComercio.Persistence.Configuration.Launchs
{
    public class LaunchConfiguration : IEntityTypeConfiguration<Launch>
    {
        public void Configure(EntityTypeBuilder<Launch> builder)
        {
            builder.ToTable(nameof(Launch));
            builder.HasKey(k => k.Id);
        }
    }
}