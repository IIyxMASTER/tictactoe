using System.Collections.Generic;
using Sources.TicTacToe.Controllers.Interfaces;
using Sources.TicTacToe.Models;
using Sources.TicTacToe.Views;
using Sources.TicTacToe.Views.Interfaces;
using UnityEngine;
using Zenject;

namespace Sources.TicTacToe.Controllers
{
    public class GameFieldController : IGameFieldController
    {
        [Inject] private GameCellView.Factory _cellFactory;
        [Inject] private IGameFieldView _view;
        [Inject] private ICameraController _cameraController;

        [SerializeField] private float _cellSize;
        [SerializeField] private float _cellPadding;
        private float FieldSize => _cellSize * 5 + _cellPadding * 8;


        private bool _isCellsCreated = false;

        public void CreateCells()
        {
            if (_isCellsCreated)
                return;
            for (int i = 0; i < 9; i++)
            {
                var cell = _cellFactory.Create();
                cell.Model = new Cell();
                _view.AddCell(cell);
            }
            _isCellsCreated = true;
        }

        public void ChangeCellStatus(Cell cell, Players player)
        {
            cell.Status = (Cell.CellStatus) player;
            _view.ChangeCellView(cell);
        }

        public Cell.CellStatus GetCellStatus(int row, int column)
        {
            return _view.GetCellAt(row, column).Status;
        }

        public List<Cell> GetFreeCells()
        {
            var toReturn = new List<Cell>();
            for (int row = 0; row < 3; row++)
            for (int column = 0; column < 3; column++)
            {
                var cell = _view.GetCellAt(row, column);
                if (cell.Status == Cell.CellStatus.Free)
                {
                    toReturn.Add(cell);
                }
            }

            return toReturn;
        }


        public void Format()
        {
            _view.Format(_cellSize, _cellPadding);
            UpdateFieldSize();
        }

        public void UpdateFieldSize()
        {
            _cameraController.FieldSize = FieldSize;
        }

        public void HideView()
        {
            _view.Hide();
        }
        public void ShowView()
        {
            _view.Show();
        }
        public void SetCellPadding(float padding)
        {
            _cellPadding = padding;
        }

        public void SetCellSize(float size)
        {
            _cellSize = size;
        }
    }
}