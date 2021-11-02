using System;

namespace Sources.TicTacToe.UI.Controllers.Interfaces
{
    public interface IMessageBoxController
    {
        
        void ShowInfoBox(string info, Action clickAction);
        void ShowYesNoBox(string info, Action yesButtonClickAction, Action noButtonClickAction);
    }
}