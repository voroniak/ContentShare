using MediatR;

namespace Notes.API.Commands.UpdateNote
{
    public class UpdateNoteCommand : IRequest
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
    }
}
