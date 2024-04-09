using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konsom.Application.Interfaces
{
    public interface IUnitOfWork
    {
        INoteRepository NoteRepository { get; }
        IReminderRepository ReminderRepository { get; }
        ITagRepository TagRepository { get; }
    }
}
