namespace Sources.TicTacToe.UI.Controllers.Interfaces
{
    public interface IOptionsUIController
    {
        void ShowView();
        void HideView();
        
        void LoadAvatars();
        void ApplySettings();

        string PlayerName { get; set; }
        float Volume { get; set; }
        string PlayerAvatar { get; set; }
        void ApplyAvatar();
    }
}