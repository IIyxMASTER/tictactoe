﻿using TicTacToe.Controllers.Interfaces;
using TicTacToe.UI;
using TicTacToe.UI.Interfaces;
using UnityEngine;
using Zenject;

// ReSharper disable ClassNeverInstantiated.Global

namespace TicTacToe.Controllers
{
    public class LevelLoaderViewController : ILevelLoaderViewController
    {
        [Inject] private ILevelLoaderView _view;

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