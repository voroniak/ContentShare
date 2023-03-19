using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Notes.API.Commands.CreateNote;
using Notes.API.Commands.DeleteNote;
using Notes.API.Commands.UpdateNote;
using Notes.API.Dtos;
using Notes.API.Queries.GetAllNotes;
using Notes.API.Queries.GetNoteById;
using Notes.API.Queries.GetNotesByName;

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

        [HttpGet("Name/{name}")]
        public async Task<ActionResult<IEnumerable<NoteDto>>> GetByName(string name)
        {
            return Ok(await _mediator.Send(new GetNotesByNameQuery { Name = name }));
        }

        [HttpGet("Id/{id}")]
        public async Task<ActionResult<NoteDto>> GetById(string id)
        {
            return Ok(await _mediator.Send(new GetNoteByIdQuery { Id = id }));
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateNoteCommand createNoteCommand)
        {
            await _mediator.Send(createNoteCommand);

            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> Put(UpdateNoteCommand updateNoteCommand)
        {
            await _mediator.Send(updateNoteCommand);

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteNoteCommand deleteNoteCommand)
        {
            await _mediator.Send(deleteNoteCommand);

            return NoContent();
        }
    }
}
