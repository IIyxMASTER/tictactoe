using UnityEngine;

namespace Sources.TicTacToe.UI.Views.Interfaces
{
    public interface IEndGameView
    {
        void ShowView();
        void HideView();

        void SetResultText(string result);
        void SetScores(int from, int to);
        void SetAvatar(Sprite avatar);
        void Animate();
        void GoToMainMenu();
        void Restart();

    }
}