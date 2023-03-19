using MediatR;
using Notes.API.Dtos;

namespace Notes.API.Queries.GetNotesByName
{
    public class GetNotesByNameQuery : IRequest<IEnumerable<NoteDto>>
    {
        public string Name { get; set; }
    }
}
