using MongoDB.Driver;
using Notes.API.Data.Interfaces;
using Notes.API.Entities;
using Notes.API.Repositories.Interfaces;

namespace Notes.API.Repositories
{
    public class NotesRepository : INotesRepository
    {
        private readonly INotesContext _context;

        public NotesRepository(INotesContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Note>> GetAllAsync()
        {
            return await _context
                            .Notes
                            .Find(p => true)
                            .ToListAsync();
        }

        public async Task<Note> GetAsync(string id)
        {
            return await _context
                           .Notes
                           .Find(p => p.Id == id)
                           .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Note>> GetNotesByNameAsync(string name)
        {
            FilterDefinition<Note> filter = Builders<Note>.Filter.ElemMatch(p => p.Name, name);

            return await _context
                            .Notes
                            .Find(filter)
                            .ToListAsync();
        }

        public async Task CreateAsync(Note note)
        {
            await _context.Notes.InsertOneAsync(note);
        }

        public async Task<bool> UpdateAsync(Note note)
        {
            var updateResult = await _context
                                        .Notes
                                        .ReplaceOneAsync(filter: g => g.Id == note.Id, replacement: note);

            return updateResult.IsAcknowledged
                    && updateResult.ModifiedCount > 0;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            FilterDefinition<Note> filter = Builders<Note>.Filter.Eq(n => n.Id, id);

            DeleteResult deleteResult = await _context
                                                .Notes
                                                .DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged
                && deleteResult.DeletedCount > 0;
        }
    }
}
