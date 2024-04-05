using Konsom.Application.Interfaces;
using Konsom.Domain;

namespace Konsom.DAL.Services.Repository
{
    public class ReminderRepository : BaseRepository<Reminder>, IReminderRepository
    {
        public ReminderRepository(ApplicationDBContext db) : base(db)
        {
        }
    }
}
