namespace Notes.API.Dtos
{
    public class NoteDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}
