using System.Collections.Generic;

namespace Sources.TicTacToe.UI.Controllers.Interfaces
{
    public interface ILevelLoaderController
    {
        IEnumerator<float>  Show();
        IEnumerator<float> Hide();
        void StartGame();
        IEnumerator<float> ShowBattleScreen();
        IEnumerator<float>  ShowEndBattleScreen();
    }
}