using Konsom.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Konsom.DAL.EntityConfiguration
{
    public class TagConfiguration : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.HasMany(e => e.Notes)
                .WithMany(e => e.Tags)
                .UsingEntity<NoteTag>();

            builder.HasMany(e => e.Reminders)
                .WithMany(e => e.Tags)
                .UsingEntity<ReminderTag>();
        }
    }
}
