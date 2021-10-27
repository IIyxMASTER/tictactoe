using System;
using Sirenix.OdinInspector;
using TicTacToe.Controllers;
using TicTacToe.Controllers.Interfaces;
using TicTacToe.Extensions;
using UnityEngine;
using Zenject;

namespace TicTacToe.Managers
{
    public class LevelManager : SerializedMonoBehaviour
    {
        [Inject, SerializeField] private ILevelLoaderViewController _levelLoaderViewController;

        private void Awake()
        {
            DontDestroyOnLoad(transform.GetRootTransform());
        }
        
        void Start()
        {
            _levelLoaderViewController.ShowMainLoadScreen();
        }
    }
}