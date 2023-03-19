using Notes.API.Entities;

namespace Notes.API.Repositories.Interfaces
{
    public interface INotesRepository
    {
        Task<IEnumerable<Note>> GetAllAsync();
        Task<Note> GetAsync(string id);
        Task<IEnumerable<Note>> GetNotesByNameAsync(string name);

        Task CreateAsync(Note note);
        Task<bool> UpdateAsync(Note note);
        Task<bool> DeleteAsync(string id);
    }
}
