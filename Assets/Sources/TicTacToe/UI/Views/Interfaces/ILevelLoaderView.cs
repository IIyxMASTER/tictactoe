﻿namespace TicTacToe.UI.Interfaces
{
    public interface ILevelLoaderView
    {
        void Show();
        void Hide();
        void ShowProgressBar(string[] filesToLoad);
    }
}