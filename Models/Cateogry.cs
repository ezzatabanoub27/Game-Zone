namespace GameHUB.Models
{
    public class Cateogry
    {
        public int Id { get; set; }
        public string Name { get; set; }


        public ICollection<Game>games { get; set; }=new List<Game>();

    }
}
