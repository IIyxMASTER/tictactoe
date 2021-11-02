using System;
using UnityEngine;

namespace Sources.TicTacToe.UI.Views.Interfaces
{
    public interface IMessageBoxView
    {
        RectTransform RectTransform { get; }
        void ShowInfoBox();
        void AddInformationText(string text);
        void AddInformationTextWithIcon(string text, Sprite icon);
        void AddTextButton(string text, Action onClick);
        void AddIconButton(string text, Sprite icon, Action onClick);
    }
}