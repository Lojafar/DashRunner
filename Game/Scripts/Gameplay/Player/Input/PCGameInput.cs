using System;
using UnityEngine;
using Zenject;
namespace Game.Gameplay.Player.Input
{
    using Input = UnityEngine.Input;
    class PCGameInput : IGameInput, ITickable
    {
        public event Action OnExtraInput;
        public event Action OnJumpInput;
        public float GetHorizontalInput()
        {
            return Input.GetAxis("Horizontal");
        }
        public void Tick()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                OnJumpInput?.Invoke();
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                OnExtraInput?.Invoke();
            }
        }

    }
}
