using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Notes.API.Commands.CreateNote;
using Notes.API.Dtos;
using Notes.API.Queries.GetAllNotes;

namespace Notes.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public NotesController(IMediator mediator,
                              IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<NoteDto>>> Get()
        {
            return Ok(await _mediator.Send(new GetAllNotesQuery()));
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateNoteCommand createNoteCommand)
        {
            await _mediator.Send(createNoteCommand);

            return NoContent();
        }
    }
}
