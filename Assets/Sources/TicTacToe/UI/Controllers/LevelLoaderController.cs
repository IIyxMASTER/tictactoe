using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using MEC;
using Sources.TicTacToe.Controllers.Interfaces;
using Sources.TicTacToe.UI.Controllers.Interfaces;
using Sources.TicTacToe.UI.Views.Interfaces;
using Sources.TicTacToe.Views.Interfaces;
using TicTacToe.Extensions;
using UnityEngine;
using Zenject;

// ReSharper disable ClassNeverInstantiated.Global

namespace Sources.TicTacToe.UI.Controllers
{
    public class LevelLoaderController : ILevelLoaderController
    {
        [Inject] private IMaskView _maskView;
        [Inject] private IMainMenuController _mainMenuController;
        [Inject] private ILevelLoaderView _levelLoaderView;
        [Inject] private IGameFieldController _gameFieldController;

        public void StartGame()
        {
            StartGame(filesToLoad: new[]
            {
                "Menu", "Icons", "Levels"
            });
        }


        private void StartGame(string[] filesToLoad)
        {
            _maskView.InstantHide();
            _mainMenuController.HideView();
            _levelLoaderView.HideView();
            _levelLoaderView.ShowView();

            Timing.RunCoroutine(PlayOpenSceneAnimation(filesToLoad,
                () =>
                {
                    _levelLoaderView.HideView();
                    _mainMenuController.ShowView();
                }));
        }

        private IEnumerator<float> PlayOpenSceneAnimation(string[] messages, Action onLoad)
        {
            yield return Timing.WaitUntilDone(Timing.RunCoroutine(Show()));
            yield return Timing.WaitUntilDone(Timing.RunCoroutine(AnimateSlider(messages, onLoad)));
        }

        public IEnumerator<float> PlayChangeSceneAnimation(string[] messages, Action onHide, Action onLoad, int animationSpriteId = 0)
        {
            yield return Timing.WaitUntilDone(Timing.RunCoroutine(Hide()));
            _levelLoaderView.ShowView(animationSpriteId);
            onHide?.Invoke();
            yield return Timing.WaitUntilDone(Timing.RunCoroutine(PlayOpenSceneAnimation(messages, onLoad)));
        }


        IEnumerator<float> AnimateSlider(string[] filesToLoad, Action onLoad)
        {
            yield return Timing.WaitForSeconds(2);


            var partsCount = 1f / filesToLoad.Length;
            for (var i = 0; i < filesToLoad.Length; i++)
            {
                yield return Timing.WaitForSeconds(1);

                _levelLoaderView.SetProgressBarText($"Load: \\{filesToLoad[i]}");

                var startPoint = partsCount * i;
                var endPoint = partsCount * (i + 1);

                yield return _levelLoaderView.SliderAnimationTime.AsTimeProcess(normalTime =>
                {
                    var sliderValue = Mathf.Lerp(startPoint, endPoint, normalTime);
                    _levelLoaderView.SetProgressBarValue(sliderValue);
                });
            }

            yield return Timing.WaitUntilDone(Timing.RunCoroutine(Hide()));
            _levelLoaderView.HideView();
            onLoad?.Invoke();
            yield return Timing.WaitUntilDone(Timing.RunCoroutine(Show()));
        }


        public IEnumerator<float> Show()
        {
            yield return Timing.WaitUntilDone(Timing.RunCoroutine(_maskView.Show(_levelLoaderView.AnimationShowTime)));
        }

        public IEnumerator<float> Hide()
        {
            yield return Timing.WaitUntilDone(Timing.RunCoroutine(_maskView.Hide(_levelLoaderView.AnimationShowTime)));
        }
    }
}