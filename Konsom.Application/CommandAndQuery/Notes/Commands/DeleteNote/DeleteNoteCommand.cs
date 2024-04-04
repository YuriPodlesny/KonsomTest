﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konsom.Application.CommandAndQuery.Notes.Commands.DeleteNote
{
    public record DeleteNoteCommand(Guid Id) : IRequest<Unit>;
}
