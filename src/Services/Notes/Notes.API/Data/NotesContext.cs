using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Notes.API.Data.Interfaces;
using Notes.API.Entities;
using Notes.API.Settings;

namespace Notes.API.Data
{
    public class NotesContext : INotesContext
    {
        public NotesContext(IOptions<NotesDatabaseSettings> options)
        {
            var mongoClient = new MongoClient(options.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(options.Value.DatabaseName);
            Notes = mongoDatabase.GetCollection<Note>(options.Value.NotesCollectionName);
        }

        public IMongoCollection<Note> Notes { get; }
    }
}
