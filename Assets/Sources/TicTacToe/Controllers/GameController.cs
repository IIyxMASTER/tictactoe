using System.Collections.Generic;
using MEC;
using Sources.TicTacToe.Controllers.Interfaces;
using Sources.TicTacToe.Models;
using Sources.TicTacToe.UI.Controllers.Interfaces;
using UnityEngine;
using Zenject;

namespace Sources.TicTacToe.Controllers
{
    public class GameController : IGameController
    {

        public void StartGame()
        {
            _levelLoaderController.StartGame();
        }

        [Inject] private ILevelLoaderController _levelLoaderController;
        [Inject] private IGameFieldController _gameFieldController;
        private Players whoseTurnNow = Players.Player;

        public void OnCellClick(Cell cellModel)
        {
            if (whoseTurnNow != Players.Player)
                return;
            if (cellModel.Status != Cell.CellStatus.Free)
                return;
            whoseTurnNow = Players.AI;
            _gameFieldController.ChangeCellStatus(cellModel, Players.Player);
            if (!CheckResult(cellModel))
            {
                Timing.RunCoroutine(AITurn());
            }
            else
            {
                Debug.Log("SHOW WIN MESSAGE");
            }
        }

        bool CheckResult(Cell cell)
        {
            return CheckRow(cell)
                   || CheckColumn(cell)
                   || CheckDiagonal(cell);
        }

        private bool CheckDiagonal(Cell cell)
        {
            var column = cell.Column;
            bool isWin = true;
            for (int x = 0; x < 3; x++)
            {
                var testCell = _gameFieldController.GetCellStatus(x, x);
                if (testCell != cell.Status)
                    isWin = false;
            }

            if (isWin)
                return true;
            isWin = true;
            for (int x = 0; x < 3; x++)
            {
                var testCell = _gameFieldController.GetCellStatus(x, 2 - x);
                if (testCell != cell.Status)
                    isWin = false;
            }

            return isWin;
        }

        bool CheckColumn(Cell cell)
        {
            bool isWin = true;
            for (int row = 0; row < 3; row++)
            {
                var testCell = _gameFieldController.GetCellStatus(row, cell.Column);
                if (testCell != cell.Status)
                    isWin = false;
            }

            return isWin;
        }

        bool CheckRow(Cell cell)
        {
            bool isWin = true;
            for (int column = 0; column < 3; column++)
            {
                var testCell = _gameFieldController.GetCellStatus(cell.Row, column);
                if (testCell != cell.Status)
                    isWin = false;
            }

            return isWin;
        }

        IEnumerator<float> AITurn()
        {
            yield return Timing.WaitForSeconds(2);
            var freeCells = _gameFieldController.GetFreeCells();
            var point = Random.Range(0, freeCells.Count);
            var cell = freeCells[point];
            whoseTurnNow = Players.Player;
            _gameFieldController.ChangeCellStatus(cell, Players.AI);
            if (CheckResult(cell))
            {
                Debug.Log("SHOW LOSE MESSAGE");
            }
        }
    }
}