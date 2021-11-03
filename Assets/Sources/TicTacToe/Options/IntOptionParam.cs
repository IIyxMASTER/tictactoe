using UnityEngine;

namespace Sources.TicTacToe.Options
{
    public class IntOptionParam : OptionParam<int>
    {
        public override int GetValue(string key) => PlayerPrefs.GetInt(key);
        public override void SetValue(string key, int value)
        {
            PlayerPrefs.SetInt(key,value);
        }

        public IntOptionParam(string key) : base(key)
        {
        }
    }
}