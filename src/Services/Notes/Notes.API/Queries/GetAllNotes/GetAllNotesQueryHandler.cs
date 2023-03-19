using AutoMapper;
using MediatR;
using Notes.API.Dtos;
using Notes.API.Repositories.Interfaces;

namespace Notes.API.Queries.GetAllNotes
{
    public class GetAllNotesQueryHandler : IRequestHandler<GetAllNotesQuery, IEnumerable<NoteDto>>
    {

        private readonly INotesRepository _notesRepository;
        private readonly IMapper _mapper;

        public GetAllNotesQueryHandler(INotesRepository notesRepository, IMapper mapper)
        {
            _notesRepository = notesRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<NoteDto>> Handle(GetAllNotesQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<IEnumerable<NoteDto>>(await _notesRepository.GetAllAsync());
        }
    }
}
