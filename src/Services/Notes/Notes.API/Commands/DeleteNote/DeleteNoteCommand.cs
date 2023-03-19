using MediatR;

namespace Notes.API.Commands.DeleteNote
{
    public class DeleteNoteCommand : IRequest
    {
        public string Id { get; set; }
    }
}
