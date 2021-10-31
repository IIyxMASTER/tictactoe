using UnityEngine;

namespace Sources.TicTacToe.UI.Views.Interfaces
{
    public interface IGameUIView
    {
        void SetPlayerName(string playerName);
        void SetEnemyName(string enemyName);
        void SetPlayerScores(int scores);
        void SetPlayerAvatar(Sprite playerAvatar);
        void SetEnemyAvatar(Sprite enemyAvatar);
        void SetVictoryCount(int victoryCount);
        void SetLevelName(string levelName);
        void ShowView();
        void HideView();
        void SetCamera(Camera uiCamera);
    }
}