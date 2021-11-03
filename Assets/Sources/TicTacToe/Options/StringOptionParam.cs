using UnityEngine;

namespace Sources.TicTacToe.Options
{
    public class StringOptionParam : OptionParam<string>
    {
        public override string GetValue(string key) => PlayerPrefs.GetString(key);
        public override void SetValue(string key, string value)
        {
            PlayerPrefs.SetString(key,value);
        }

        public StringOptionParam(string key) : base(key)
        {
        }
    }

   
}