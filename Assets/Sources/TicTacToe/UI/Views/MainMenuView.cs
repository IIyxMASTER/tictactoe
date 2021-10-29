using Sources.TicTacToe.UI.Controllers.Interfaces;
using Sources.TicTacToe.UI.Views.Interfaces;
using UnityEngine;
using Zenject;

namespace Sources.TicTacToe.UI.Views
{
    public class MainMenuView : MonoBehaviour, IMainMenuView
    {
        [Inject] private IMainMenuController _controller;

        [SerializeField] private Canvas _menuCanvas;

        public void Hide()
        {
            _menuCanvas.enabled = false;
        }

        public void Show()
        {
            _menuCanvas.enabled = true;
        }

        public void OnClickOptions()
        {
            _controller.OnClickOptions();
        }

        public void OnClickPlay()
        {
            _controller.OnClickPlay();
        }
    }
}