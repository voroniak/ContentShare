using MediatR;
using Notes.API.Repositories.Interfaces;

namespace Notes.API.Commands.DeleteNote
{
    public class DeleteNoteCommandHandler : IRequestHandler<DeleteNoteCommand>
    {
        private readonly INotesRepository _notesRepository;

        public DeleteNoteCommandHandler(INotesRepository notesRepository)
        {
            _notesRepository = notesRepository;
        }

        public async Task Handle(DeleteNoteCommand request, CancellationToken cancellationToken)
        {

            await _notesRepository.DeleteAsync(request.Id);
        }
    }
}
