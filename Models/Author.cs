using System.ComponentModel.DataAnnotations;

namespace DayMvctoApi.Models
{
    public class Author
    {
        public int id { get; set; }

        [Required]
        public string Name { get; set; }
        public List<string>? bookTitle { get; set; }
    }
}
