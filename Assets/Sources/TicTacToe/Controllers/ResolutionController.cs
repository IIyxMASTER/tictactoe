using Sources.TicTacToe.Controllers.Interfaces;
using UnityEngine;
using Zenject;
#pragma warning disable 0649

namespace Sources.TicTacToe.Controllers
{
    public class ResolutionController : MonoBehaviour
    {
        [Inject] private ICameraController _cameraController;

        void Start()
        {
            _width = Screen.width;
            _height = Screen.height;
        }

        private int _width;
        private int _height;

        void Update()
        {
            if (Screen.height != _height || Screen.width != _width)
            {
                _cameraController.FixCameraOrthographicSizeSize();
                _width = Screen.width;
                _height = Screen.height;
            }
        }
    }
}