namespace Fitzilla.DAL.Models
{
    public class BlobObject
    {
        public string? Uri { get; set; }
        public string? Name { get; set; }
        public Stream? Content { get; set; }
        public string? ContentType { get; set; }
    }
}
