namespace DayMvctoApi.Models
{
    public class bookwithAuthor
    {

        public string Title { get; set; }
        public string Isbn { get; set; }
        public int PageCount { get; set; }
        public int id { get; set; }
        public decimal Price { get; set; }
        public string Publisher { get; set; }
        public string? AuthersName { get; set; }
        public int? AuthorId { get; set; }
    }
}
