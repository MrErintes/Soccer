using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Soccer.Core.Entities;

namespace Blogs.Infrastructure.Database.TypeConfigurations
{
    public class TeamEntityTypeConfiguration : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(30);
            builder.Property(x => x.ManagerEmail).HasMaxLength(30);
        }
    }
}
