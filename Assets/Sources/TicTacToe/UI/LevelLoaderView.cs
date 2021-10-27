using System.Collections;
using System.Collections.Generic;
using JoshH.UI;
using MEC;
using TicTacToe.Extensions;
using TicTacToe.UI.Interfaces;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace TicTacToe.UI
{
    public class LevelLoaderView : MonoBehaviour, ILevelLoaderView
    {
//    [Inject] private LevelLoaderController _view;
        [SerializeField] private VerticalLayoutGroup _verticalLayoutGroup;
        [SerializeField] private Canvas _canvas;
        [SerializeField] private UIGradient _uiGradient;

        public void Show()
        {
            _canvas.enabled = true;
        }

        public void Hide()
        {
            Debug.Log("Hide");
        }

        public void ShowProgressBar(string[] filesToLoad)
        {
            foreach (var file in filesToLoad)
            {
                Debug.Log(file);
            }

            Timing.RunCoroutine(Animate(filesToLoad, 10));
        }

        private IEnumerator<float> Animate(string[] filesToLoad, int i)
        {
            yield return Timing.WaitUntilDone(Timing.RunCoroutine(ChangeColorFromTop(i)));
        }

        private IEnumerator<float> ChangeColorFromTop(float time)
        {
            var gradient = _uiGradient.LinearGradient;
            var keys = gradient.colorKeys;
            var tempArray = new GradientColorKey[keys.Length];
            yield return time.AsTimeProcess(normalTime =>
            {
                for (var i = 0; i < keys.Length; i++)
                {
                    var key = keys[i];
                    var value = Mathf.Lerp(key.time, 1, normalTime);
                    key.time = value;
                    tempArray[i] = key;
                }

                gradient.colorKeys = tempArray;
                _uiGradient.LinearGradient = gradient;
            });
        }
    }
}