using System;
using Sources.TicTacToe.Controllers;

namespace Sources.TicTacToe.Options
{
    public abstract class OptionParam<T>
    {
        public event ChangeOptionValueEvent OnChangeEvent;
        public abstract T GetValue(string key);
        public abstract void SetValue(string key, T value);
        private string _key;
        public OptionParam(string key)
        {
            _key = key;
        }
        public T Value
        {
            get => GetValue(_key);
            set
            {
                SetValue(_key, value);
                OnChangeEvent?.Invoke();
            }
        }
    }
}