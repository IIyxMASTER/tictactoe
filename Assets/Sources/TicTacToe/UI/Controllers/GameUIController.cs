using System;
using Sources.TicTacToe.Controllers.Interfaces;
using Sources.TicTacToe.UI.Controllers.Interfaces;
using Sources.TicTacToe.UI.Views.Interfaces;
using UnityEngine;
using Zenject;

#pragma warning disable 0649
namespace Sources.TicTacToe.UI.Controllers
{
    public class GameUIController : IGameUIController
    {
        [Inject] private IGameUIView _gameUIView;
        [Inject] private Camera _mainCamera;
        [Inject] private IDatabaseController _database;
        [Inject] private IMessageBoxController _messageBoxController;
        [Inject] private IEndGameController _endGameController;
        [Inject] private IOptionsUIController _optionsUIController;

        public void Show()
        {
            _database.PlayerAvatar.OnChangeEvent += OnChangeAvatar;
            _database.PlayerName.OnChangeEvent += OnChangeName;
            _database.PlayerScores.OnChangeEvent += OnChangeScores;
            _database.PlayerVictories.OnChangeEvent += OnChangeVictories;

            OnChangeAvatar();
            OnChangeName();
            OnChangeScores();
            OnChangeVictories();

            _gameUIView.ShowView();
            _gameUIView.SetCamera(_mainCamera);
        }

        private void OnChangeVictories()
        {
            _gameUIView.SetVictoryCount(_database.PlayerVictories.Value);
        }

        private void OnChangeAvatar()
        {
            _gameUIView.SetPlayerAvatar(_database.GetPlayerAvatar());
        }

        private void OnChangeName()
        {
            
            _gameUIView.SetPlayerName(_database.PlayerName.Value);
        }

        private void OnChangeScores()
        {
            _gameUIView.SetPlayerScores(_database.PlayerScores.Value);
        }

        public void Hide()
        {
            _gameUIView.HideView();
            _database.PlayerAvatar.OnChangeEvent -= OnChangeAvatar;
            _database.PlayerName.OnChangeEvent -= OnChangeName;
            _database.PlayerScores.OnChangeEvent -= OnChangeScores;
            _database.PlayerVictories.OnChangeEvent -= OnChangeVictories;
        }

        public void ClickExitButton()
        {
            _messageBoxController.ShowCustomButtons("Вы хотите выйти или попробовать еще раз?",
                new Tuple<string, Action>[]
                {
                    new Tuple<string, Action>("Exit", () =>
                    {
                        _optionsUIController.HideView();
                        _messageBoxController.HideView();
                        _endGameController.GoToMainMenu();
                    }),
                    new Tuple<string, Action>("Restart", () =>
                    {
                        _optionsUIController.HideView();
                        _messageBoxController.HideView();
                        _endGameController.Restart();
                    }),
                    new Tuple<string, Action>("Cancel", () => { _messageBoxController.HideView(); })
                }
            );
        }

        public void ClickOptionButton()
        {
            _optionsUIController.ShowView();
        }

        public void HideRightColumn()
        {
            _gameUIView.HideRight();
        }
    }
}