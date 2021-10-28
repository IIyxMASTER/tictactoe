using Sources.TicTacToe.UI.Controllers.Interfaces;
using TicTacToe.UI.Interfaces;
using UnityEngine;
using Zenject;

// ReSharper disable ClassNeverInstantiated.Global

namespace Sources.TicTacToe.UI.Controllers
{
    public class LevelLoaderController : ILevelLoaderController
    {
        [Inject] private ILevelLoaderView _view;

        public void StartGame()
        {
            ShowMainLoadScreen();
        }
        
        public void ShowMainLoadScreen()
        {
            _view.Show();
            _view.ShowProgressBar(filesToLoad: new[]
            {
                "Menu", "Icons", "Levels"
            });
        }

        public void ShowStartBattleScreen()
        {
            Debug.Log("One");
        }

        public void ShowEndBattleScreen()
        {
            Debug.Log("One");
        }
    }
}