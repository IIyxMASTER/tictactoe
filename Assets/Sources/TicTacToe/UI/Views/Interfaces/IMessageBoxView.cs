using System;
using UnityEngine;

namespace Sources.TicTacToe.UI.Views.Interfaces
{
    public interface IMessageBoxView
    {
        RectTransform RectTransform { get; }
        void ShowView();
        void HideView();
        void SetInformationText(string text);
        void AddButton(string text, Action onClick);
        void Flush();
    }
}