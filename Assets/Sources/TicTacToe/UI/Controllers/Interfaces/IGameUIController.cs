namespace Sources.TicTacToe.UI.Controllers.Interfaces
{
    public interface IGameUIController
    {
        void Show();
        void Hide();
        void ClickExitButton();
        void ClickOptionButton();

        void HideRightColumn();
    }
}