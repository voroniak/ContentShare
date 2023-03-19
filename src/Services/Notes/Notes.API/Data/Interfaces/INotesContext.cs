using MongoDB.Driver;
using Notes.API.Entities;

namespace Notes.API.Data.Interfaces
{
    public interface INotesContext
    {
        IMongoCollection<Note> Notes { get; }

    }
}
