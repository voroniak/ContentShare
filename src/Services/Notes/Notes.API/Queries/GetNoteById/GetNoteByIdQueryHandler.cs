using AutoMapper;
using MediatR;
using Notes.API.Dtos;
using Notes.API.Entities;
using Notes.API.Repositories.Interfaces;

namespace Notes.API.Queries.GetNoteById
{
    public class GetNoteByIdQueryHandler : IRequestHandler<GetNoteByIdQuery, NoteDto>
    {

        private readonly INotesRepository _notesRepository;
        private readonly IMapper _mapper;

        public GetNoteByIdQueryHandler(INotesRepository notesRepository, IMapper mapper)
        {
            _notesRepository = notesRepository;
            _mapper = mapper;
        }

        public async Task<NoteDto> Handle(GetNoteByIdQuery request, CancellationToken cancellationToken)
        {
            Note note = await _notesRepository.GetAsync(request.Id);

            if (note == null)
            {
                return null;
            }

            return _mapper.Map<NoteDto>(note);
        }
    }
}
