using Game.Gameplay.Player.Movement;
namespace Game.Gameplay.Player.Animation
{
    public interface IPlayerAnimChanger
    {
        public void HandleNewMovement(MovementType movementType);
    }
}
