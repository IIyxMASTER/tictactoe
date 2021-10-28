using Sources.TicTacToe.Models;

namespace Sources.TicTacToe.Controllers.Interfaces
{
    public interface IGameController
    {
        void StartGame();
        void OnCellClick(Cell cellModel);
    }
}