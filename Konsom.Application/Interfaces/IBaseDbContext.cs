using Konsom.Domain;
using Microsoft.EntityFrameworkCore;


namespace Konsom.Application.Interfaces
{
    public interface IBaseDbContext
    {
        public DbSet<Note> Notes { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Reminder> Reminders { get; set; }

        public Task<int> SaveChangesAsync(CancellationToken cancellation);
    }
}
