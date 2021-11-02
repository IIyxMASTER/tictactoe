using System;
using System.Collections.Generic;
using Sources.TicTacToe.UI.Controllers.Interfaces;
using Sources.TicTacToe.UI.Views.Interfaces;
using TMPro;
using UnityEngine;
using Zenject;

namespace Sources.TicTacToe.UI.Views
{
    public class MessageBoxView : MonoBehaviour, IMessageBoxView
    {
        [Inject] private IMessageBoxController _messageBoxController;
        
        public void ClickOnYes()
        {
        }

        public void ClickOnNo()
        {
        }


        public RectTransform RectTransform => transform as RectTransform;

        public void ShowInfoBox()
        {
            
        }

        public void AddInformationText(string text)
        {
            
        }

        public void AddInformationTextWithIcon(string text, Sprite icon)
        {
            
        }

        public void AddTextButton(string text, Action onClick)
        {
           
        }

        public void AddIconButton(string text, Sprite icon, Action onClick)
        {
           
        }
    }
    public class MessageBoxViewFactory : PlaceholderFactory<IMessageBoxView>
    {
    }
    public class MessageBoxButtonViewFactory : PlaceholderFactory<IMessageBoxButtonView>
    {
    }
}