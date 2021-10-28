using System.Collections.Generic;
using MEC;
using Sources.TicTacToe.UI.Controllers.Interfaces;
using Sources.TicTacToe.UI.Views.Interfaces;
using Sources.TicTacToe.Views.Interfaces;
using TicTacToe.Extensions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Sources.TicTacToe.UI.Views
{
    public class LevelLoaderView : MonoBehaviour, ILevelLoaderView
    {
        [Inject] private ILevelLoaderController _levelLoaderController;
        [SerializeField] private Canvas _canvas;
        [SerializeField] private Slider _slider;
        [SerializeField] private TMP_Text _sliderText;
        [SerializeField] private Transform _animateObject;
        [SerializeField] private float _showAnimationTime;
        [SerializeField] private float _sliderAnimationTime;

        public float AnimationShowTime => _showAnimationTime;
        public float SliderAnimationTime => _sliderAnimationTime;

        public IEnumerator<float> ShowAnimatedObject(float time, int objectId)
        {
            _canvas.enabled = true;
            _animateObject.gameObject.SetActive(true);
            yield return Timing.WaitUntilDone(Timing.RunCoroutine(_levelLoaderController.Show()));
            yield return Timing.WaitForSeconds(time);
            yield return Timing.WaitUntilDone(Timing.RunCoroutine(_levelLoaderController.Hide()));
            _animateObject.gameObject.SetActive(false);
            _canvas.enabled = false;
        }

        public void Show()
        {
            _canvas.enabled = true;

            _slider.gameObject.SetActive(true);
            _animateObject.gameObject.SetActive(true);
        }

        public void Hide()
        {
            _canvas.enabled = false;
            _slider.gameObject.SetActive(false);
            _animateObject.gameObject.SetActive(false);
        }

        public void SetProgressBarText(string text)
        {
            _sliderText.text = text;
        }

        public void SetProgressBarValue(float value)
        {
            _slider.value = value;
        }
    }
}