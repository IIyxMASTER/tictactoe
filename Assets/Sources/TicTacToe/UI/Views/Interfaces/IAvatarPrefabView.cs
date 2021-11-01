using UnityEngine;

namespace Sources.TicTacToe.UI.Views.Interfaces
{
    public interface IAvatarPrefabView
    {
        RectTransform Transform { get; }
        void SetSprite(Sprite sprite, string id);
    }
}