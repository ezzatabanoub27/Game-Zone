namespace GameHUB.Models
{
    public class GameDevice
    {
        public int gameId { get; set; }
        public Game game { get; set; }

        public int deviceId { get; set; }
        public Device device { get; set; }

    }
}
