namespace MusicLib.DAL.Entities
{  
    public class Team
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Coach { get; set; }  
        
        public ICollection<Player>? Players { get; set; }
    }
}
