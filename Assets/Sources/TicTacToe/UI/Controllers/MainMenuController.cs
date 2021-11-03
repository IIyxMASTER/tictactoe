using System.Collections.Generic;
using System.Runtime.InteropServices;
using MEC;
using Sources.TicTacToe.Controllers;
using Sources.TicTacToe.Controllers.Interfaces;
using Sources.TicTacToe.Models;
using Sources.TicTacToe.UI.Controllers.Interfaces;
using Sources.TicTacToe.UI.Views.Interfaces;
using Sources.TicTacToe.Views.Interfaces;
using UnityEngine;
using Zenject;

#pragma warning disable 0649

namespace Sources.TicTacToe.UI.Controllers
{
    public class MainMenuController : IMainMenuController
    {
        [Inject] private ILevelLoaderController _levelLoaderController;
        [Inject] private IOptionsUIController _optionsUIController;
        [Inject] private IGameFieldController _gameFieldController;
        [Inject] private IGameUIController _gameUIController;
        [Inject] private IGameController _gameController;
        [Inject] private IMessageBoxController _messageBoxController;
        [Inject] private IMainMenuView _view;
        [Inject] private InputController _inputController;

        private bool _isActive;

        public void ShowView()
        {
            _isActive = true;
            _view.Show();
            _gameUIController.Show();
            _gameUIController.HideRightColumn();
        }

        public void HideView()
        {
            _isActive = false;
            _view.Hide();
        }

        public void OnClickOptions()
        {
            _optionsUIController.ShowView();
        }

        public void OnClickPlay()
        {
            Timing.RunCoroutine(Play());
        }

        public void SubscribeOnInputEvents()
        {
            _inputController.OnPressEsc += OnPressEsc;
        }

        private void OnPressEsc()
        {
            if (_isActive)
            {
                _messageBoxController.ShowYesNoBox("Вы хотите выйти?",
                    () =>
                    {
#if UNITY_STANDALONE
                        Application.Quit();
#endif

#if UNITY_EDITOR
                        UnityEditor.EditorApplication.isPlaying = false;
#endif
                        _messageBoxController.HideView();
                    },
                    () => { _messageBoxController.HideView(); }
                );
            }
        }

        IEnumerator<float> Play()
        {
            int spriteId = 1;
            yield return Timing.WaitUntilDone(_levelLoaderController.PlayChangeSceneAnimationWithFakeAction(
                onHide: HideView,
                onLoad: () =>
                {
                    _gameFieldController.ShowView();
                    _gameController.Init();
                    _gameUIController.Show();
                },
                fakeActions: new[] {"Загружаем уровень", "Тренируем AI"},
                animationSpriteId: spriteId
            ));
        }
        //
    }
}