using Sources.TicTacToe.Models;

namespace TicTacToe.Controllers.Interfaces
{
    public interface IGameController
    {
        void StartGame();
        void OnCellClick(Cell cellModel);
    }
}