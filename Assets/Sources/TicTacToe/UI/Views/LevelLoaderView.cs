using System.Collections.Generic;
using MEC;
using TicTacToe.Extensions;
using TicTacToe.UI.Interfaces;
using TicTacToe.Views;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Sources.TicTacToe.UI.Views
{
    public class LevelLoaderView : MonoBehaviour, ILevelLoaderView
    {
        [Inject] private IMaskView _maskView;
        [SerializeField] private VerticalLayoutGroup _verticalLayoutGroup;
        [SerializeField] private Canvas _canvas;
        [SerializeField] private Slider _slider;
        [SerializeField] private TMP_Text _sliderText;
        [SerializeField] private Transform _animateObject;
        [SerializeField] private float _showAnimationTime;


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
            _maskView.InstantHide();
            Timing.RunCoroutine(AnimateSlider(filesToLoad));
        }

        private IEnumerator<float> ShowScreen()
        {
            _animateObject.gameObject.SetActive(false);
            yield return Timing.WaitForSeconds(2);
            yield return Timing.WaitUntilDone(Timing.RunCoroutine(_maskView.Show(_showAnimationTime)));
        }

        [SerializeField] private float _sliderTimeAnimation = 0.1f;

        IEnumerator<float> AnimateSlider(string[] filesToLoad)
        {
            yield return Timing.WaitForSeconds(2);
            _slider.gameObject.SetActive(true);
            _animateObject.gameObject.SetActive(true);
            var partsCount = 1f / filesToLoad.Length;
            for (var i = 0; i < filesToLoad.Length; i++)
            {
                yield return Timing.WaitForSeconds(1);
                
                _sliderText.text = $"Load: \\{filesToLoad[i]}";
                
                var startPoint = partsCount * i;
                var endPoint = partsCount * (i + 1);
                
                yield return _sliderTimeAnimation.AsTimeProcess(normalTime =>
                {
                    var sliderValue = Mathf.Lerp(startPoint, endPoint, normalTime);
                    _slider.value = sliderValue;
                });
            }

            _slider.gameObject.SetActive(false);
            yield return Timing.WaitUntilDone(Timing.RunCoroutine(ShowScreen()));
        }
    }
}