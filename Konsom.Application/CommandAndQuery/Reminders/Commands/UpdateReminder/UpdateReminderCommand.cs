using Konsom.Application.Models.Reminder;
using Konsom.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konsom.Application.CommandAndQuery.Reminders.Commands.UpdateReminder
{
    public class UpdateReminderCommand : IRequest<ReminderDTO>
    {
        public string Title { get; set; } = string.Empty;
        public string Text { get; set; } = string.Empty;
        public DateTime Time { get; set; } = DateTime.Now;

        public IList<Tag> Tag { get; set; } = new List<Tag>();
    }
}
