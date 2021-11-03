namespace Sources.TicTacToe.UI.Controllers.Interfaces
{
    public interface IEndGameController
    {
        void ShowView();
        void HideView();
        void DisplayVictory(int oldScores, int newScores);
        void DisplayDefeat(int oldScores, int newScores);
        void DisplayDraw(int scores);
        void GoToMainMenu();
        void Restart();
    }
}