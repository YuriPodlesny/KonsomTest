using Konsom.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konsom.Tests.Infrastructure
{
    public abstract class TestCommandBase : IDisposable
    {
        protected readonly ApplicationDBContext _dbContext;

        public TestCommandBase()
        {
            _dbContext = NoteContextFactory.Create();
        }

        public void Dispose()
        {
            NoteContextFactory.Destroy(_dbContext);
        }
    }
}
