using System.Collections.Generic;
using System.Runtime.InteropServices;
using MEC;
using Sources.TicTacToe.Controllers.Interfaces;
using Sources.TicTacToe.Models;
using Sources.TicTacToe.UI.Controllers.Interfaces;
using Sources.TicTacToe.Views.Interfaces;
using UnityEngine;
using Zenject;

namespace Sources.TicTacToe.UI.Controllers
{
    public class MainMenuController : IMainMenuController
    {
        [Inject] private ILevelLoaderController _levelLoaderController;
        [Inject] private IGameFieldController _gameFieldController;
        [Inject] private IMainMenuView _view;

        public void ShowView()
        {
            _view.Show();
        }

        public void HideView()
        {
            _view.Hide();
        }

        public void OnClickOptions()
        {
            Debug.Log("Options");
        }

        public void OnClickPlay()
        {
            Timing.RunCoroutine(Play());
        }

        IEnumerator<float> Play()
        {
            int spriteId = 1;
            yield return Timing.WaitUntilDone(Timing.RunCoroutine(
                _levelLoaderController.PlayChangeSceneAnimation(
                    new[] {"Загружаем уровень", "Тренируем AI"},
                    () => { HideView(); },
                    () => { _gameFieldController.ShowView(); }, spriteId)));
        }
    }
}