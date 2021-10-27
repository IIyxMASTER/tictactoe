using System.Collections.Generic;
using Sources.TicTacToe.Models;

namespace TicTacToe.Controllers.Interfaces
{
    public interface IGameFieldController
    {
        void Format();
        void SetCellPadding(float padding);
        void SetCellSize(float size);
        void CreateCells();

        void ChangeCellStatus(Cell cell, Players player);

        Cell.CellStatus GetCellStatus(int row, int column);
        
        List<Cell> GetFreeCells();

    }
}