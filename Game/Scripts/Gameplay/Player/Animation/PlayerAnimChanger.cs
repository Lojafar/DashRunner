using Game.Gameplay.Player.Movement;
using UnityEngine;
namespace Game.Gameplay.Player.Animation
{
    class PlayerAnimChanger : IPlayerAnimChanger
    {
        readonly Animator playerAnimator;
        MovementType lastMovementType;
        public PlayerAnimChanger(Player _player)
        {
            playerAnimator = _player.PlayerAnimator;
        }
        public void HandleNewMovement(MovementType movementType)
        {
            CancelLastAction();
            switch (movementType)
            {
                case MovementType.Standing:
                    playerAnimator.SetBool("isRunning", false);
                    break;
                case MovementType.Running:
                    playerAnimator.SetBool("isRunning", true);
                    break;
                case MovementType.Jump:
                    playerAnimator.SetBool("isJumped", true);
                    playerAnimator.SetTrigger("Jump");
                    break;
            }
            lastMovementType = movementType;
        }
        void CancelLastAction()
        {
            switch (lastMovementType)
            {
                case MovementType.Jump:
                    playerAnimator.SetBool("isJumped", false);
                    break;
            }
        }
    }
}
