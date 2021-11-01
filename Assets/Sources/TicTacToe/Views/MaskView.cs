using System.Collections.Generic;
using Sources.TicTacToe.Controllers.Interfaces;
using Sources.TicTacToe.Views.Interfaces;
using TicTacToe.Extensions;
using UnityEngine;
using Zenject;

namespace Sources.TicTacToe.Views
{
    public class MaskView : MonoBehaviour, IMaskView
    {
        [Inject] private ICameraController _cameraController;

        [SerializeField] private Transform _holeSprite;
        [SerializeField] private Transform _maskSprite;

        private float GetMaxSize => Mathf.Max(_cameraController.Width, _cameraController.Height);

        public IEnumerator<float> Show(float time)
        {
            var targetSize = GetMaxSize;
            yield return time.AsTimeProcess(normalTime =>
            {
                var size = Mathf.Lerp(0, targetSize, normalTime);
                _holeSprite.localScale = new Vector3(size, size, size);
            });
            _holeSprite.localScale = new Vector3(targetSize, targetSize, targetSize);
            _maskSprite.gameObject.SetActive(false);
        }

        public IEnumerator<float> Hide(float time)
        {
            _maskSprite.gameObject.SetActive(true);
            var targetSize = GetMaxSize;
            yield return time.AsTimeProcess(normalTime =>
            {
                var size = Mathf.Lerp(targetSize, 0, normalTime);
                _holeSprite.localScale = new Vector3(size, size, size);
            });
            _holeSprite.localScale = Vector3.zero;
        }

        public void InstantHide()
        {
            _holeSprite.localScale = Vector3.zero;
            _maskSprite.gameObject.SetActive(true);
        }

        public void InstantShow()
        {
            var targetSize = GetMaxSize;
            _holeSprite.localScale = new Vector3(targetSize, targetSize, targetSize);

            _maskSprite.gameObject.SetActive(false);
        }
    }
}