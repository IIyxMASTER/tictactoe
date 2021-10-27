namespace Sources.TicTacToe.Models
{
    public class Cell
    {
        public int Row { get; set; }
        public int Column { get; set; }
        public CellStatus Status = CellStatus.Free;
        public enum CellStatus
        {
            Free = 0,
            Player = 1,
            AI = 2
        }
       
    }
}