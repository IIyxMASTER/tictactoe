using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace TicTacToe.Controllers
{
    using System.Runtime.InteropServices;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;


    public class CameraController : MonoBehaviour
    {
     
        public Vector3 Position => _camera.transform.position;
        public float Height => 2 * _camera.orthographicSize;

        [Inject] private Camera _mainCamera;

        private void Awake()
        {
            if(_camera == null)
                _camera = Camera.main;
        }

        [FormerlySerializedAs("camera")] [SerializeField] private Camera _camera;
        public Camera Camera => _camera;

        [Button]
        void ShowInfo()
        {
            var height = 2 * _camera.orthographicSize;
            // ReSharper disable once ArrangeTypeMemberModifiers
            var width = height * _camera.aspect;
            Debug.Log($"Width =<{width}>; Height =<{height}>");
        }

        [Button]
        public void SetWidth(float width)
        {
            var height = width / _camera.aspect;
            _camera.orthographicSize = height / 2f;
        }

        // ReSharper disable once ArrangeTypeMemberModifiers
        float Width
        {
            get
            {
                var height = 2 * _camera.orthographicSize;
                return height * _camera.aspect;
            }
        }

        private float MaxHeight => 13.5f;
        private float BasicWidth => 18f;

        private float offset;

        void Start()
        {
            SetWidth(BasicWidth);
            var height = 2 * _camera.orthographicSize;
            offset = (MaxHeight - height) / 2f;
        }

        [Button]
        void Reset()
        {
            SetWidth(18f);
        }
        
      
    }

}