using MediatR;
using Notes.API.Dtos;

namespace Notes.API.Queries.GetAllNotes
{
    public class GetAllNotesQuery : IRequest<IEnumerable<NoteDto>>
    {
    }
}
