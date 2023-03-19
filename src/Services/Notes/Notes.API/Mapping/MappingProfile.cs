using AutoMapper;
using Notes.API.Commands.CreateNote;
using Notes.API.Dtos;
using Notes.API.Entities;

namespace Notes.API.Mapping
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateNoteCommand, Note>().ReverseMap();
            CreateMap<NoteDto, Note>().ReverseMap();
        }
    }
}
