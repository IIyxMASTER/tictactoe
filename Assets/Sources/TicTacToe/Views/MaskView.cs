using System.Collections.Generic;
using TicTacToe.Controllers;
using TicTacToe.Controllers.Interfaces;
using TicTacToe.Extensions;
using UnityEngine;
using Zenject;

namespace TicTacToe.Views
{
    public class MaskView : MonoBehaviour, IMaskView
    {
        [Inject] private ICameraController _cameraController;

        [SerializeField] private Transform _holeSprite;
        
        private float GetMaxSize => Mathf.Max(_cameraController.Width, _cameraController.Height);
        
        public IEnumerator<float> Show(float time)
        {
            var targetSize = GetMaxSize;
            yield return time.AsTimeProcess(normalTime =>
            {
                var size = Mathf.Lerp(0, targetSize, normalTime);
                _holeSprite.localScale = new Vector3(size, size, size);
            });
        }

        public IEnumerator<float> Hide(float time)
        {
            var targetSize = GetMaxSize;
            yield return time.AsTimeProcess(normalTime =>
            {
                var size = Mathf.Lerp(targetSize, 0, normalTime);
                _holeSprite.localScale = new Vector3(size, size, size);
            });
        }

        public void InstantHide()
        {
            _holeSprite.localScale = Vector3.zero;
            
        }
    }

    public interface IMaskView
    {
        IEnumerator<float> Show(float time);
        IEnumerator<float> Hide(float time);
        void InstantHide();
    }
}