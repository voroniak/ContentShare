using AutoMapper;
using MediatR;
using Notes.API.Entities;
using Notes.API.Repositories.Interfaces;

namespace Notes.API.Commands.CreateNote
{
    public class CreateNoteCommandHandler : IRequestHandler<CreateNoteCommand>
    {
        private readonly INotesRepository _notesRepository;
        private readonly IMapper _mapper;

        public CreateNoteCommandHandler(INotesRepository notesRepository, IMapper mapper)
        {
            _notesRepository = notesRepository;
            _mapper = mapper;
        }

        public async Task Handle(CreateNoteCommand request, CancellationToken cancellationToken)
        {
           Note newNote = _mapper.Map<Note>(request);

           await _notesRepository.CreateAsync(newNote);
        }
    }
}
