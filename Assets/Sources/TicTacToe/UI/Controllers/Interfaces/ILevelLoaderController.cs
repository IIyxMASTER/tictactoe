using System;
using System.Collections.Generic;

namespace Sources.TicTacToe.UI.Controllers.Interfaces
{
    public interface ILevelLoaderController
    {
        float ShowAnimation { get; }
    
        float HideAnimation { get; }
        void StartGame();
        IEnumerator<float> AnimateSlider(string message, float sliderProgress);
        IEnumerator<float> EndSliderAnimation(Action onLoad);
        IEnumerator<float> PlayChangeSceneAnimation( Action onHide,  int animationSpriteId);
  
    }
}