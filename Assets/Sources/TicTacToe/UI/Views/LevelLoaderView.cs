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
#pragma warning disable 0649
namespace Sources.TicTacToe.UI.Views
{
    public class LevelLoaderView : MonoBehaviour, ILevelLoaderView
    {
        [Inject] private ILevelLoaderController _levelLoaderController;
        [SerializeField] private Canvas _canvas;
        [SerializeField] private Slider _slider;
        [SerializeField] private TMP_Text _sliderText;
        [SerializeField] private Transform[] _animateObject;
        [SerializeField] private float _showAnimationTime;
        [SerializeField] private float _sliderAnimationTime;

        public float AnimationShowTime => _showAnimationTime;
        public float SliderAnimationTime => _sliderAnimationTime;

        public IEnumerator<float> ShowAnimatedObject(float time, int objectId)
        {
            _canvas.enabled = true;
            ActivateAnimatedObject(true,objectId );
            yield return _levelLoaderController.ShowAnimation;
            yield return Timing.WaitForSeconds(time);
            yield return _levelLoaderController.HideAnimation;
            ActivateAnimatedObject(false,objectId );
            _canvas.enabled = false;
        }

        public void ShowView(int animationSpriteId = 0)
        {
            _canvas.enabled = true;

            _slider.gameObject.SetActive(true);
            ActivateAnimatedObject(true, animationSpriteId);
        }

        void ActivateAnimatedObject(bool setActive, int id)
        {
            if (!setActive)
            {
                foreach (var animatedObject in _animateObject)
                {
                    animatedObject.gameObject.SetActive(false);
                }
            }
            else
            {
                for (int i = 0; i < _animateObject.Length; i++)
                {
                    _animateObject[i].gameObject.SetActive(i == id);
                }
            }
        }

        public void HideView()
        {
            _canvas.enabled = false;
            _slider.gameObject.SetActive(false);
            ActivateAnimatedObject(false,0 );
        }

        public void SetProgressBarText(string text)
        {
            _sliderText.text = text;
        }

        public float ProgressBarValue
        {
            get => _slider.value;
            set => _slider.value = value;
        }
    }
}