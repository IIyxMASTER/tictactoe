using Sources.TicTacToe.UI.Controllers.Interfaces;
using Sources.TicTacToe.UI.Views.Interfaces;
using UnityEngine;
using Zenject;

namespace Sources.TicTacToe.UI.Controllers
{
    public class GameUIController : IGameUIController
    {
        [Inject] private IGameUIView _gameUIView;
        [Inject] private Camera _mainCamera;
        public void Show()
        {
            _gameUIView.ShowView();
            _gameUIView.SetCamera(_mainCamera);
        }

        public void Hide()
        {
            _gameUIView.HideView();
        }
    }
}