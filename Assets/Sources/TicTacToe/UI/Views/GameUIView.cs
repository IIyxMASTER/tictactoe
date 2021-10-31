using Sources.TicTacToe.UI.Views.Interfaces;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Sources.TicTacToe.UI.Views
{
    public class GameUIView : MonoBehaviour, IGameUIView
    {
        [SerializeField] private Image _playerAvatarRenderer;
        [SerializeField] private TMP_Text _playerNameLabel;
        [SerializeField] private TMP_Text _playerScoresLabel;
        [SerializeField] private TMP_Text _playerVictoryCountsLabel;
        [SerializeField] private TMP_Text _levelNameLabel;


        [SerializeField] private Image _aiAvatarRenderer;
        [SerializeField] private TMP_Text _aiNameLabel;

        [SerializeField] private Canvas _canvas;

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
    }
}