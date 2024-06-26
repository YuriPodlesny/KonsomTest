﻿using Konsom.Application.Models.Dto;
using MediatR;

namespace Konsom.Application.CommandAndQuery.Notes.Queries.GetNotes
{
    public record GetNotesQuery : IRequest<List<NoteDTO>>;
}
