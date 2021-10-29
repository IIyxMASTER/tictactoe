using System.Collections.Generic;

namespace Sources.TicTacToe.UI.Views.Interfaces
{
    public interface ILevelLoaderView
    {
        void HideView();
        void ShowView(int animationSpriteId = 0);
        void SetProgressBarText(string text);
        float ProgressBarValue { get; set; }

        float AnimationShowTime { get; }
        float SliderAnimationTime { get; }
        IEnumerator<float> ShowAnimatedObject(float time, int objectId);
    }
}