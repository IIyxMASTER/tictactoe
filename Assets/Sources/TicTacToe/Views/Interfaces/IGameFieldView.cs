using Sources.TicTacToe.Models;

namespace Sources.TicTacToe.Views.Interfaces
{
    public interface IGameFieldView
    {
        void Format(float cellSize, float padding);
        void AddCell(IGameCellView cell);
        Cell GetCellAt(int row, int column);

        void ChangeCellView(Cell cell);

        void Show();
        void Hide();
    }
}