using Konsom.Application.Interfaces;
using Konsom.DAL.EntityConfiguration;
using Konsom.Domain;
using Microsoft.EntityFrameworkCore;

namespace Konsom.DAL
{
    public class ApplicationDBContext : DbContext, IBaseDbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
            : base(options)
        {

        }

        public DbSet<Note> Notes { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Reminder> Reminders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new NoteConfiguration())
                        .ApplyConfiguration(new ReminderConfiguration())
                        .ApplyConfiguration(new TagConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
