using Konsom.Application.CommandAndQuery.Notes.Commands.AddNote;
using Konsom.Application.CommandAndQuery.Notes.Commands.DeleteNote;
using Konsom.Application.CommandAndQuery.Notes.Commands.UpdateNote;
using Konsom.Application.CommandAndQuery.Notes.Queries.GetNote;
using Konsom.Application.CommandAndQuery.Notes.Queries.GetNotes;
using Konsom.Application.CommandAndQuery.Reminders.Commands.AddReminder;
using Konsom.Application.CommandAndQuery.Reminders.Commands.DeleteReminder;
using Konsom.Application.CommandAndQuery.Reminders.Commands.UpdateReminder;
using Konsom.Application.CommandAndQuery.Reminders.Queries.GetReminder;
using Konsom.Application.CommandAndQuery.Reminders.Queries.GetReminders;
using Konsom.Application.CommandAndQuery.Tags.Commands.AddTag;
using Konsom.Application.CommandAndQuery.Tags.Commands.DeleteTag;
using Konsom.Application.CommandAndQuery.Tags.Commands.UpdateTag;
using Konsom.Application.CommandAndQuery.Tags.Queries.GetTag;
using Konsom.Application.CommandAndQuery.Tags.Queries.GetTags;
using Konsom.Application.Models.Dto;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Konsom.Application.DIExtensions
{
    public static class DIExtension
    {
        public static IServiceCollection AddApplications(this IServiceCollection services)
        {
            return services
                .AddScoped<IRequestHandler<AddNoteCommand, Unit>, AddNoteCommandHandler>()
                .AddScoped<IRequestHandler<DeleteNoteCommand, Unit>, DeleteNoteCommandHandler>()
                .AddScoped<IRequestHandler<UpdateNoteCommand, Unit>, UpdateNoteCommandHandler>()
                .AddScoped<IRequestHandler<GetNoteByIdQuery, NoteDTO>, GetNoteByIdQueryHandler>()
                .AddScoped<IRequestHandler<GetNotesQuery, List<NoteDTO>>, GetNotesQueryHandler>()

                .AddScoped<IRequestHandler<AddReminderCommand, Unit>, AddReminderCommandHandler>()
                .AddScoped<IRequestHandler<DeleteReminderCommand, Unit>, DeleteReminderCommandHandler>()
                .AddScoped<IRequestHandler<UpdateReminderCommand, Unit>, UpdateReminderCommandHandler>()
                .AddScoped<IRequestHandler<GetReminderByIdQuery, ReminderDTO>, GetReminderByIdQueryHandler>()
                .AddScoped<IRequestHandler<GetRemindersQuery, List<ReminderDTO>>, GetRemindersQueryHendler>()

                .AddScoped<IRequestHandler<AddTagCommand, Unit>, AddTagCommandHandler>()
                .AddScoped<IRequestHandler<DeleteTagCommand, Unit>, DeleteTagCommandHandler>()
                .AddScoped<IRequestHandler<UpdateTagCommand, Unit>, UpdateTagCommandHandler>()
                .AddScoped<IRequestHandler<GetTagByIdQuery, TagDTO>, GetTagByIdQueryHandler>()
                .AddScoped<IRequestHandler<GetTagsQuery, List<TagDTO>>, GetTagsQueryHandler>();

            //.AddAutoMapper(typeof(MappingConfig))
            //.AddValidatorsFromAssemblies(new[] { Assembly.GetExecutingAssembly() });
        }
    }
}
