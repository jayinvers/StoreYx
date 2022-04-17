namespace StoreYx.Models
{
    public class Page
    {
        public int Id { get; set; }
        public string Path { get; set; }
        public string Title { get; set; }
        
        public string? Subtitle { get; set; }
        public string? Thumbnail { get; set; }
        public string? Description { get; set; }
        public string? HtmlBody { get; set; }
        public string? MarkdownBody { get; set; }

   
        public DateTime? CreatedAt { get; set; }


    }
}
