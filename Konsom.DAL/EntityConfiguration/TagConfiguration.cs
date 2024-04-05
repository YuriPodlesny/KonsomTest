using Konsom.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Konsom.DAL.EntityConfiguration
{
    public class TagConfiguration : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasMany(x => x.Notes)
                .WithMany(x => x.Tag);
        }
    }
}
