using Sources.TicTacToe.UI.Controllers.Interfaces;
using Sources.TicTacToe.UI.Views.Interfaces;
using Sources.TicTacToe.Views;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

#pragma warning disable 0649

namespace Sources.TicTacToe.UI.Views
{
    public class GameUIView : MonoBehaviour, IGameUIView
    {
        [SerializeField] private Image _playerAvatarRenderer;
        [SerializeField] private TMP_Text _playerNameLabel;
        [SerializeField] private TMP_Text _playerScoresLabel;
        [SerializeField] private TMP_Text _playerVictoryCountsLabel;
        [SerializeField] private TMP_Text _levelNameLabel;

        [Inject] private IGameUIController _gameUIController;

        [SerializeField] private Image _aiAvatarRenderer;
        [SerializeField] private TMP_Text _aiNameLabel;

        [SerializeField] private Canvas _canvas;
        [SerializeField] private GameObject _rightColumn;

        public void HideRight()
        {
            _rightColumn.SetActive(false);
        }

        public void SetPlayerName(string playerName)
        {
            _playerNameLabel.text = playerName;
        }

        public void SetEnemyName(string enemyName)
        {
            _aiNameLabel.text = enemyName;
        }

        public void SetPlayerScores(int scores)
        {
            _playerScoresLabel.text = $"Scores: {scores.ToString()}";
        }

        public void SetPlayerAvatar(Sprite playerAvatar)
        {
            _playerAvatarRenderer.sprite = playerAvatar;
            _playerAvatarRenderer.gameObject.SetActive(playerAvatar != null);
        }

        public void SetEnemyAvatar(Sprite enemyAvatar)
        {
            _aiAvatarRenderer.sprite = enemyAvatar;
        }

        public void SetVictoryCount(int victoryCount)
        {
            _playerVictoryCountsLabel.text = $"Victories: {victoryCount.ToString()}";
        }

        public void SetLevelName(string levelName)
        {
            _levelNameLabel.text = levelName;
        }

        public void ShowView()
        {
            _canvas.enabled = true;
            _rightColumn.SetActive(true);
        }

        public void HideView()
        {
            _canvas.enabled = false;
        }

        public void SetCamera(Camera uiCamera)
        {
            if (_canvas.worldCamera == null)
                _canvas.worldCamera = uiCamera;
        }

        public void ClickExitButton()
        {
            _gameUIController.ClickExitButton();
        }

        public void ClickOptionButton()
        {
            _gameUIController.ClickOptionButton();
        }
    }
}