using Sources.TicTacToe.Models;
using TicTacToe.Controllers;
using TicTacToe.Controllers.Interfaces;
using UnityEngine;

namespace TicTacToe.Views
{
    public interface IGameCellView
    {
        Cell Model { get; set; }
        void Construct(IGameController controller);
        void SetParent(Transform parent);
        void SetPosition(Vector3 position);
        void SetSize(Vector3 size);
    }
}