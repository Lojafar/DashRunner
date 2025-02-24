using System;
namespace Game.Gameplay.Player.Input
{
    public interface IGameInput 
    {
        public float GetHorizontalInput();
        public event Action OnExtraInput;
        public event Action OnJumpInput;
    }
}
