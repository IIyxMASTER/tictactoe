﻿using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using Sources.TicTacToe.Models;
using TicTacToe.Controllers;
using TicTacToe.Views.Interfaces;
using UnityEngine;
using Zenject;

namespace TicTacToe.Views
{
    public class GameFieldView : MonoBehaviour, IGameFieldView
    {
        [SerializeField] private List<IGameCellView> _cells;


        [Button]
        public void Format(float cellSize, float padding)
        {
            for (int column = -1; column < 2; column++)
            {
                for (int row = -1; row < 2; row++)
                {
                    var position = (column + 1) * 3 + (row + 1);
                    var cell = _cells[position];
                    cell.Model.Column = column + 1;
                    cell.Model.Row = row + 1;

                    var x = column * cellSize + column * padding;
                    var y = row * cellSize + row * padding;
                    cell.SetPosition(new Vector3(x, y, 0));
                    cell.SetSize(new Vector3(cellSize, cellSize, cellSize));
                }
            }
        }

        public void AddCell(IGameCellView cell)
        {
            if (_cells == null)
                _cells = new List<IGameCellView>(9);
            _cells.Add(cell);
            cell.SetParent(transform);
        }

        public Cell GetCellAt(int row, int column)
        {
            var position = column * 3 + row;
            return _cells[position].Model;
        } 
        public IGameCellView GetCellViewAt(Cell cell)
        {
            return GetCellViewAt(cell.Row, cell.Column);
        }
        public IGameCellView GetCellViewAt(int row, int column)
        {
            var position = column * 3 + row;
            return _cells[position];
        }

        public void ChangeCellView(Cell cell)
        {
            var cellView = GetCellViewAt(cell);
            cellView.Model = cell;
        }
    }
}