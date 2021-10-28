using System.Collections.Generic;

namespace Sources.TicTacToe.Views.Interfaces
{
    public interface IMaskView
    {
        IEnumerator<float> Show(float time);
        IEnumerator<float> Hide(float time);
        void InstantHide();
        void InstantShow();
    }
}