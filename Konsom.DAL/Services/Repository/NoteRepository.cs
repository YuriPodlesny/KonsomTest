using Konsom.Application.Interfaces;
using Konsom.Domain;
using Microsoft.EntityFrameworkCore;

namespace Konsom.DAL.Services.Repository
{
    public class NoteRepository : BaseRepository<Note>, INoteRepository
    {
        private readonly ApplicationDBContext _db;
        public NoteRepository(ApplicationDBContext db) : base(db)
        {
            _db = db;
        }


        public override async Task<Note?> GetById(Guid? id)
        {
            return await _db.NoteTag.Where(e => e.NoteId == id)
                .Include(e => e.Note)
                .Include(e => e.Tag)
                .Select(e => new Note
                {
                    Id = e.NoteId,
                    Title = e.Note.Title,
                    Text = e.Note.Text,
                    Tags = new List<Tag>
                    {
                        e.Tag
                    },
                }).FirstOrDefaultAsync(); 
        }

        public override async Task<IEnumerable<Note>> GetAllAsync()
        {
            return await _db.NoteTag
                .Include(e => e.Note)
                .Include(e => e.Tag)
                .Select(e => new Note
                {
                    Id = e.NoteId,
                    Title = e.Note.Title,
                    Text = e.Note.Text,
                    Tags = new List<Tag>
                    {
                        e.Tag
                    },
                }).ToListAsync();
        }
    }
}
