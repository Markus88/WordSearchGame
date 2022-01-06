namespace WordSearchGame
{
    public class GridInformations
    {
        public string[] Words { get; set; }
        public char[,] Grid { get; set; }
        public char[,] WinningGridLocation { get; set; }
    }
}