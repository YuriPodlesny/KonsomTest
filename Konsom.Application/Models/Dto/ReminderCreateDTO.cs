﻿using Konsom.Domain;

namespace Konsom.Application.Models.Dto
{
    public class ReminderCreateDTO
    {
        public string Title { get; set; } = string.Empty;
        public string Text { get; set; } = string.Empty;
        public DateTime Time { get; set; } = DateTime.Now;

        public IList<Tag> Tag { get; set; } = new List<Tag>();
    }
}
