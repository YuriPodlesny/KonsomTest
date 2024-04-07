using AutoMapper;
using Konsom.Application.CommandAndQuery.Notes.Commands.AddNote;
using Konsom.Application.CommandAndQuery.Notes.Commands.UpdateNote;
using Konsom.Application.CommandAndQuery.Reminders.Commands.AddReminder;
using Konsom.Application.CommandAndQuery.Reminders.Commands.UpdateReminder;
using Konsom.Application.CommandAndQuery.Tags.Commands.AddTag;
using Konsom.Application.CommandAndQuery.Tags.Commands.UpdateTag;
using Konsom.Application.Models.Dto;
using Konsom.Domain;

namespace Konsom.Application.Mapping
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<Note, NoteDTO>().ReverseMap();
            CreateMap<Note, AddNoteCommand>().ReverseMap();
            CreateMap<Note, UpdateNoteCommand>().ReverseMap();

            CreateMap<Reminder, ReminderDTO>().ReverseMap();
            CreateMap<Reminder, AddReminderCommand>().ReverseMap();
            CreateMap<Reminder, UpdateReminderCommand>().ReverseMap();

            CreateMap<Tag, TagDTO>().ReverseMap();
            CreateMap<Tag, AddTagCommand>().ReverseMap();
            CreateMap<Tag, UpdateTagCommand>().ReverseMap();
        }
    }
}
