using AutoMapper;
using MediatR;
using Notes.API.Dtos;
using Notes.API.Repositories.Interfaces;

namespace Notes.API.Queries.GetNotesByName
{
    public class GetNotesByNameQueryHandler : IRequestHandler<GetNotesByNameQuery, IEnumerable<NoteDto>>
    {

        private readonly INotesRepository _notesRepository;
        private readonly IMapper _mapper;

        public GetNotesByNameQueryHandler(INotesRepository notesRepository, IMapper mapper)
        {
            _notesRepository = notesRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<NoteDto>> Handle(GetNotesByNameQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<IEnumerable<NoteDto>>(await _notesRepository.GetNotesByNameAsync(request.Name));
        }
    }
}
