using MediatR;

namespace Notes.API.Commands.CreateNote
{
    public class CreateNoteCommand: IRequest
    {
        public string Name { get; set; }
        public string Text { get; set; }
    }
}
