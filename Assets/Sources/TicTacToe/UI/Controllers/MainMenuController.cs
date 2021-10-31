using System.Collections.Generic;
using System.Runtime.InteropServices;
using MEC;
using Sources.TicTacToe.Controllers.Interfaces;
using Sources.TicTacToe.Models;
using Sources.TicTacToe.UI.Controllers.Interfaces;
using Sources.TicTacToe.UI.Views.Interfaces;
using Sources.TicTacToe.Views.Interfaces;
using UnityEngine;
using Zenject;

namespace Sources.TicTacToe.UI.Controllers
{
    public class MainMenuController : IMainMenuController
    {
        [Inject] private ILevelLoaderController _levelLoaderController;
        [Inject] private IGameFieldController _gameFieldController;
        [Inject] private IGameUIController _gameUIController;
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
            yield return Timing.WaitUntilDone(
                _levelLoaderController.PlayChangeSceneAnimation(
                    () => { HideView(); },
                    spriteId)
            );
            var fakeActions = new[] {"Загружаем уровень", "Тренируем AI"};
            for (int i = 0; i < fakeActions.Length; i++)
            {
                yield return Timing.WaitUntilDone(
                    _levelLoaderController.AnimateSlider(fakeActions[i], (float) i / (fakeActions.Length - 1)));
            }

            yield return Timing.WaitUntilDone(_levelLoaderController.EndSliderAnimation(
                () =>
                {
                    _gameFieldController.ShowView();
                    _gameUIController.Show();
                }
            ));
        }
        //
    }
}