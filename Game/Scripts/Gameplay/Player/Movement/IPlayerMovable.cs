using System;
using UnityEngine;
namespace Game.Gameplay.Player.Movement
{
    public interface IPlayerMovable
    {
        public event Action<MovementType> OnMovementChanged;
        public void Move(float direction);
        public void Jump();
        public void Extra();
        public void HandleCollisionStart(Collision2D collision);
    }
}
