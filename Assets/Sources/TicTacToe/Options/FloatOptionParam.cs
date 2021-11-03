using UnityEngine;

namespace Sources.TicTacToe.Options
{
    public class FloatOptionParam : OptionParam<float>
    {
        public override float GetValue(string key) => PlayerPrefs.GetFloat(key);
        public override void SetValue(string key, float value)
        {
            PlayerPrefs.SetFloat(key,value);
        }

        public FloatOptionParam(string key) : base(key)
        {
        }
    }
}