using System;
using Sources.TicTacToe.Controllers.Interfaces;
using Sources.TicTacToe.UI.Controllers.Interfaces;
using Sources.TicTacToe.UI.Views;
using Sources.TicTacToe.UI.Views.Interfaces;
using UnityEngine;
using Zenject;
#pragma warning disable 0649

namespace Sources.TicTacToe.UI.Controllers
{
    public class MessageBoxController : IMessageBoxController
    {
        [Inject(Id = "AlertSprite")] private Sprite _alertSprite;
        [Inject] private IMessageBoxView _messageBoxView;
        
        public void ShowInfoBox(string info,string buttonText, Action clickAction)
        {
            _messageBoxView.Flush();
            _messageBoxView.SetInformationText(info);
            _messageBoxView.AddButton("<sprite=0>"+buttonText,clickAction);
            _messageBoxView.ShowView();
        }

        public void ShowYesNoBox(string info, Action yesButtonClickAction, Action noButtonClickAction)
        {
            _messageBoxView.Flush();
            _messageBoxView.SetInformationText(info);
            _messageBoxView.AddButton("<sprite=0>Yes", yesButtonClickAction);
            _messageBoxView.AddButton("<sprite=1>No", noButtonClickAction);
            _messageBoxView.ShowView();
        }
        

        public void ShowCustomButtons(string info, Tuple<string, Action>[] buttons)
        {
            
            _messageBoxView.Flush();
            _messageBoxView.SetInformationText(info);
            foreach (Tuple<string, Action> button in buttons)
            {
                _messageBoxView.AddButton(button.Item1, button.Item2);
            }
            _messageBoxView.ShowView();
        }

        public void ShowView()
        {
            _messageBoxView.ShowView();
        }

        public void HideView()
        {
            _messageBoxView.HideView();
        }
    }
}