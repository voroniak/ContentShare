using MediatR;
using Notes.API.Dtos;

namespace Notes.API.Queries.GetNoteById
{
    public class GetNoteByIdQuery : IRequest<NoteDto>
    {
        public string Id { get; set; }
    }
}
