using System.Collections;
using System.Collections.Generic;
using Sources.TicTacToe.UI.Controllers.Interfaces;
using Sources.TicTacToe.Views.Interfaces;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Sources.TicTacToe.Views
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