using System;
using Sources.TicTacToe.Controllers.Interfaces;
using Sources.TicTacToe.UI.Controllers.Interfaces;
using Sources.TicTacToe.UI.Views;
using Sources.TicTacToe.UI.Views.Interfaces;
using UnityEngine;
using Zenject;

namespace Sources.TicTacToe.UI.Controllers
{
    public class MessageBoxController : IMessageBoxController
    {
        [Inject(Id = "AlertSprite")] private Sprite _alertSprite;
        [Inject] private MessageBoxViewFactory _messageBoxViewFactory;
        [Inject] private MessageBoxButtonViewFactory _messageBoxButtonViewFactory;

        public void ShowInfoBox(string info, Action clickAction)
        {
        }

        public void ShowYesNoBox(string info, Action yesButtonClickAction, Action noButtonClickAction)
        {
            var box = _messageBoxViewFactory.Create();
        }
    }
}