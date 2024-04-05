using Konsom.Application.Interfaces;
using Konsom.Domain;

namespace Konsom.DAL.Services.Repository
{
    public class NoteRepository : BaseRepository<Note>, INoteRepository
    {
        public NoteRepository(ApplicationDBContext db) : base(db)
        {
        }
    }
}
