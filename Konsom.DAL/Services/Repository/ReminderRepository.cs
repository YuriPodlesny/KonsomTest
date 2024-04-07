using Konsom.Application.Interfaces;
using Konsom.Domain;
using Microsoft.EntityFrameworkCore;

namespace Konsom.DAL.Services.Repository
{
    public class ReminderRepository : BaseRepository<Reminder>, IReminderRepository
    {
        private readonly ApplicationDBContext _db;
        public ReminderRepository(ApplicationDBContext db) : base(db)
        {
            _db = db;
        }

        public override async Task<Reminder?> GetById(Guid? id)
        {
            return await _db.ReminderTag.Where(e => e.ReminderId == id)
                .Include(e => e.Reminder)
                .Include(e => e.Tag)
                .Select(e => new Reminder
                {
                    Id = e.ReminderId,
                    Title = e.Reminder.Title,
                    Text = e.Reminder.Text,
                    Time = e.Reminder.Time,
                    Tags = new List<Tag>
                    {
                        e.Tag
                    }
                }).FirstOrDefaultAsync();
        }

        public override async Task<IEnumerable<Reminder>> GetAllAsync()
        {
            return await _db.ReminderTag
                .Include(e => e.Reminder)
                .Include(e => e.Tag)
                .Select(e => new Reminder
                {
                    Id = e.ReminderId,
                    Title = e.Reminder.Title,
                    Text = e.Reminder.Text,
                    Time = e.Reminder.Time,
                    Tags = new List<Tag>
                    {
                        e.Tag
                    }
                }).ToListAsync();
        }
    }
}
