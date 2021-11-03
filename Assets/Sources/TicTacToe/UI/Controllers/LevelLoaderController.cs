using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using MEC;
using Sources.TicTacToe.Controllers.Interfaces;
using Sources.TicTacToe.UI.Controllers.Interfaces;
using Sources.TicTacToe.UI.Views.Interfaces;
using Sources.TicTacToe.Views.Interfaces;
using TicTacToe.Extensions;
using Unity.Collections;
using UnityEngine;
using Zenject;

// ReSharper disable ClassNeverInstantiated.Global
#pragma warning disable 0649
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
            _levelLoaderView.ShowView();

            Timing.RunCoroutine(StartGameAnimation());
        }

        IEnumerator<float> StartGameAnimation()
        {
            yield return ShowAnimation;
            var fakeResources = new[] {"Load folders", "Load sprites", "Load scenes", "Load Animations"};
            var fakeLoadTime = new[] {1, 2, 1.2f, 1};
            for (int i = 0; i < fakeResources.Length; i++)
            {
                yield return Timing.WaitForSeconds(fakeLoadTime[i]);
                yield return Timing.WaitUntilDone(
                    AnimateSlider(fakeResources[i], (float) i / (fakeResources.Length - 1)));
            }

            yield return Timing.WaitUntilDone(EndSliderAnimation(() =>
            {
                _levelLoaderView.HideView();
                _mainMenuController.ShowView();
                
            }));
        }

        public float ShowAnimation => Timing.WaitUntilDone(_maskView.Show(_levelLoaderView.AnimationShowTime));
        public float HideAnimation => Timing.WaitUntilDone(_maskView.Hide(_levelLoaderView.AnimationShowTime));

        public IEnumerator<float> PlayChangeSceneAnimation(Action onHide,
            int animationSpriteId = 0)
        {
            yield return HideAnimation;
            _levelLoaderView.ProgressBarValue = 0;
            _levelLoaderView.ShowView(animationSpriteId);
            onHide?.Invoke();
            yield return ShowAnimation;
        }

        public IEnumerator<float> PlayChangeSceneAnimationWithFakeAction(Action onHide, Action onLoad,
            string[] fakeActions,
            int animationSpriteId)
        {
            yield return Timing.WaitUntilDone(
                PlayChangeSceneAnimation(
                    onHide,
                    animationSpriteId)
            );
            for (int i = 0; i < fakeActions.Length; i++)
            {
                yield return Timing.WaitUntilDone(
                    AnimateSlider(fakeActions[i], (float) i / (fakeActions.Length - 1)));
            }

            yield return Timing.WaitUntilDone(EndSliderAnimation(
                onLoad
            ));
        }

        public IEnumerator<float> AnimateSlider(string message, float sliderProgress)
        {
            _levelLoaderView.SetProgressBarText(message);

            var startPoint = _levelLoaderView.ProgressBarValue;
            yield return _levelLoaderView.SliderAnimationTime.AsTimeProcess(normalTime =>
            {
                var sliderValue = Mathf.Lerp(startPoint, sliderProgress, normalTime);
                _levelLoaderView.ProgressBarValue = sliderValue;
            });
            _levelLoaderView.ProgressBarValue = sliderProgress;
        }

        public IEnumerator<float> EndSliderAnimation(Action onLoad)
        {
            yield return HideAnimation;
            _levelLoaderView.HideView();
            onLoad?.Invoke();
            yield return ShowAnimation;
        }
    }
}