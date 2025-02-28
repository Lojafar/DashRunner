using Game.Gameplay.Player.Movement;
namespace Game.Gameplay.Player.Animation
{
    public interface IVisualAnimator
    {
        public void HandleNewMovement(MovementType movementType);
    }
}
