using System;

namespace Sources.TicTacToe.UI.Controllers.Interfaces
{
    public interface IMessageBoxController
    {
        
        void ShowInfoBox(string info, string buttonText,Action clickAction);
        void ShowYesNoBox(string info, Action yesButtonClickAction, Action noButtonClickAction);

        void ShowCustomButtons(string info, Tuple<string, Action>[] buttons);
        void ShowView();
        void HideView();
    }
}