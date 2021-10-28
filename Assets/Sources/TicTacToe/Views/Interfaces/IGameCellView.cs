using Sources.TicTacToe.Controllers.Interfaces;
using Sources.TicTacToe.Models;
using UnityEngine;

namespace Sources.TicTacToe.Views.Interfaces
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