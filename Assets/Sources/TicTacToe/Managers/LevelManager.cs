using Sirenix.OdinInspector;
using TicTacToe.Controllers;
using TicTacToe.Controllers.Interfaces;
using UnityEngine;
using Zenject;

namespace TicTacToe.Managers
{
    public class LevelManager : SerializedMonoBehaviour
    {
        [Inject, SerializeField] private ILevelLoaderViewController _levelLoaderViewController;

        void Start()
        {
            _levelLoaderViewController.ShowMainLoadScreen();
            _levelLoaderViewController.ShowStartBattleScreen();
            _levelLoaderViewController.ShowEndBattleScreen();
        }
    }
}