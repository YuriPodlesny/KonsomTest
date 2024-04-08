using Konsom.DAL;
using Konsom.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konsom.Tests.Infrastructure
{
    public class NoteContextFactory
    {
        public static Guid NoteIdForDelete = Guid.NewGuid(); 
        public static Guid NoteIdForUpdate = Guid.NewGuid();
        public static Guid NoteIdForGet = Guid.NewGuid();

        public static ApplicationDBContext Create()
        {
            var options = new DbContextOptionsBuilder<ApplicationDBContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var context = new ApplicationDBContext(options);
            context.Database.EnsureCreated();
            context.Notes.AddRange(
                new Domain.Note
                {
                    Id = NoteIdForGet,
                    Text = "Test1",
                    Title = "Test1",
                    Tags = new List<Tag>
                    {
                        new Tag
                        {
                            Id = Guid.Parse("29fb1752-fdcf-475c-8681-f70efc7e50d2"),
                            Name = "TegTast1"
                        },
                        new Tag
                        {
                            Id = Guid.Parse("cb28c008-8566-4516-abf6-4ac137eef013"),
                            Name = "TegTest2"
                        }
                    }
                },
                new Domain.Note
                {
                    Id = NoteIdForDelete,
                    Text = "Test2",
                    Title = "Test2",
                    Tags = new List<Tag>
                    {
                        new Tag
                        {
                            Id = Guid.Parse("dc564d2b-ce4b-4800-abc2-ed38b5ffabd6"),
                            Name = "TegTast3"
                        },
                        new Tag
                        {
                            Id = Guid.Parse("123ee992-1c32-430d-bf4f-9d3c5ef588d6"),
                            Name = "TegTest4"
                        }
                    }
                },
                new Domain.Note
                {
                    Id = NoteIdForUpdate,
                    Text = "Test1",
                    Title = "Test1",
                    Tags = new List<Tag>
                    {
                        new Tag
                        {
                            Id = Guid.Parse("29fb1752-fdcf-475c-8681-f70efc7e50d2"),
                            Name = "TegTast1"
                        },
                        new Tag
                        {
                            Id = Guid.Parse("cb28c008-8566-4516-abf6-4ac137eef013"),
                            Name = "TegTest2"
                        }
                    }
                }
                );
            context.SaveChanges();
            return context;
        }

        public static void Destroy(ApplicationDBContext context)
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}
