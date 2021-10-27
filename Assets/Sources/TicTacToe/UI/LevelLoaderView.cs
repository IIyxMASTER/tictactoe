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
[SerializeField]
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

            //Timing.RunCoroutine(Animate(filesToLoad, 2));
        }

        private IEnumerator<float> Animate(string[] filesToLoad, int i)
        {
            yield return Timing.WaitForSeconds(2);
            yield return Timing.WaitUntilDone(Timing.RunCoroutine(ChangeColorFromBottom(i)));
            yield return Timing.WaitForSeconds(2);
            yield return Timing.WaitUntilDone(Timing.RunCoroutine(ChangeColorFromTop(i)));
        }

        private IEnumerator<float> ChangeColorFromTop(float time)
        {
            var height = _canvas.GetComponent<RectTransform>().rect.height;
            var rTransform = _uiGradient.GetComponent<RectTransform>();
            yield return time.AsTimeProcess(normalTime =>
            {
                var y = Mathf.Lerp(0, height, normalTime);
                rTransform.SetRect(0,y,0,0);
            });
        }
        private IEnumerator<float> ChangeColorFromBottom(float time)
        {
            var height = _canvas.GetComponent<RectTransform>().rect.height;
            var rTransform = _uiGradient.GetComponent<RectTransform>();
            yield return time.AsTimeProcess(normalTime =>
            {
                var y = Mathf.Lerp(height, -20, normalTime);
                rTransform.SetRect(0,y,0,0);
            });
        }
    }
}