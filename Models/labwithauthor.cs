namespace DayMvctoApi.Models
{
    public class labwithauthor
    {
        public int id { get; set; }
        public string name { get; set; }
        public string adress { get; set; }
        public List<int>? Author_id{ get; set; }
        public List<string>? auhtors { get; set; }
    }
}
