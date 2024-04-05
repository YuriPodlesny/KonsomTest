using Konsom.Application.Interfaces;
using Konsom.Domain;

namespace Konsom.DAL.Services.Repository
{
    public class TagRepository : BaseRepository<Tag>, ITagRepository
    {
        public TagRepository(ApplicationDBContext db) : base(db)
        {
        }
    }
}
