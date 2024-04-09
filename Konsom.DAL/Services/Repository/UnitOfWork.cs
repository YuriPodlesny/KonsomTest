using Konsom.Application.Interfaces;

namespace Konsom.DAL.Services.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public INoteRepository NoteRepository => throw new NotImplementedException();

        public IReminderRepository ReminderRepository => throw new NotImplementedException();

        public ITagRepository TagRepository => throw new NotImplementedException();
    }
}
