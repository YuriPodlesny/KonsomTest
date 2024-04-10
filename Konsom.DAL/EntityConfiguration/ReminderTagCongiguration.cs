using Konsom.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Konsom.DAL.EntityConfiguration
{
    public class ReminderTagCongiguration : IEntityTypeConfiguration<ReminderTag>
    {
        public void Configure(EntityTypeBuilder<ReminderTag> builder)
        {
            builder.HasKey(e => new { e.ReminderId, e.TagId });
        }
    }
}
