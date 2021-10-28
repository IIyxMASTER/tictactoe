using System;
using System.Collections.Generic;

namespace Sources.TicTacToe.UI.Controllers.Interfaces
{
    public interface ILevelLoaderController
    {
        IEnumerator<float>  Show();
        IEnumerator<float> Hide();
        void StartGame();

        IEnumerator<float> PlayChangeSceneAnimation(string[] messages, Action onHide, Action onLoad, int animationSpriteId);
  
    }
}