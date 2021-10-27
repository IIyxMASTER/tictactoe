using System;
using System.Collections.Generic;
using MEC;

namespace TicTacToe.Extensions
{
    public static class TweenExtension
    {
        public static float AsTimeProcess(this float time, Action<float> onChangeValue)
        {
            return Timing.WaitUntilDone(Timing.RunCoroutine(LerpTime()));

            IEnumerator<float> LerpTime()
            {
                float timeLeft = 0;
                while (timeLeft < time)
                {
                    var normal = timeLeft / time;
                    onChangeValue(normal);
                    yield return Timing.WaitForOneFrame;
                    timeLeft += Timing.DeltaTime;
                }
            }
        }
    }
}