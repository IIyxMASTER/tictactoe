using Sources.TicTacToe.Controllers.Interfaces;
using UnityEngine;
using Zenject;

namespace Sources.TicTacToe.Controllers
{
    public class CameraController : ICameraController
    {
        public float Height => 2 * _camera.orthographicSize;
        public float Width => 2 * _camera.orthographicSize * _camera.aspect;
        [Inject] private Camera _camera;
        
        
        private float _fieldSize;
        public void FixCameraOrthographicSizeSize()
        {
            var height = 2 * _camera.orthographicSize;
            var width = height * _camera.aspect;
            //10 = 2 * 5
            //h = w / camera.aspect
            //width  / camera.aspect = 2 * _camera.orto
            
            if (height > width)
            {
                var newHeight = _fieldSize / _camera.aspect;
                _camera.orthographicSize = newHeight / 2f;
            }
            else
            {
                _camera.orthographicSize = _fieldSize / _camera.aspect / 2f;
            }
        }

        public float FieldSize
        {
            set
            {
                _fieldSize = value;
                FixCameraOrthographicSizeSize();
            }
            get => _fieldSize;
        }

        public CameraController()
        {
        }
    }
}