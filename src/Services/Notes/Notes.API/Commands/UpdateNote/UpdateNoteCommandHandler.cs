using AutoMapper;
using MediatR;
using Notes.API.Entities;
using Notes.API.Repositories.Interfaces;

namespace Notes.API.Commands.UpdateNote
{
    public class UpdateNoteCommandHandler : IRequestHandler<UpdateNoteCommand>
    {
        private readonly INotesRepository _notesRepository;

        public UpdateNoteCommandHandler(INotesRepository notesRepository)
        {
            _notesRepository = notesRepository;
        }

        public async Task Handle(UpdateNoteCommand request, CancellationToken cancellationToken)
        {
            Note noteToUpdate = await _notesRepository.GetAsync(request.Id);

            if (noteToUpdate == null)
            {
                return;
            }

            noteToUpdate.Name = request.Name;
            noteToUpdate.Text = request.Text;
            noteToUpdate.ModifiedAt = DateTime.UtcNow;

            await _notesRepository.UpdateAsync(noteToUpdate);
        }
    }
}
