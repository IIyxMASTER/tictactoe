using UnityEngine;

namespace Sources.TicTacToe.Controllers
{
    public delegate void OnPressEsc();
    
    public class InputController : MonoBehaviour
    {
        public event OnPressEsc OnPressEsc;
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                OnPressEsc?.Invoke();
            }
        }
    }
}