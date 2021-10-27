namespace TicTacToe.Controllers.Interfaces
{
    public interface ILevelLoaderController
    {
        void StartGame();
        void ShowMainLoadScreen();
        void ShowStartBattleScreen();
        void ShowEndBattleScreen();
    }
}