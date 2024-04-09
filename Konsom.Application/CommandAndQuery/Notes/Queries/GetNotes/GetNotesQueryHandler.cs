using AutoMapper;
using Konsom.Application.Models.Dto;
using Konsom.Application.Interfaces;
using MediatR;

namespace Konsom.Application.CommandAndQuery.Notes.Queries.GetNotes
{
    public class GetNotesQueryHandler : IRequestHandler<GetNotesQuery, List<NoteDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetNotesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<NoteDTO>> Handle(GetNotesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var notesFromDB = await _unitOfWork.NoteRepository.GetAllAsync();
                if (notesFromDB == null)
                {
                    throw new Exception("Данные не найдены");
                }

                return _mapper.Map<List<NoteDTO>>(notesFromDB);
            }
            catch (Exception)
            {
                throw;
            } 
        }
    }
}
