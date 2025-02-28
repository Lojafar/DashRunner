using Game.Gameplay.Player.Movement;
using UnityEngine;
using Zenject;
namespace Game.Gameplay.Player.Animation
{
    class VisualAnimator : MonoBehaviour, IVisualAnimator
    {
        [SerializeField] Animator playerAnimator;
        [SerializeField] TrailRenderer backTrail;
        MovementType lastMovementType;
        [Inject]
        public void Construct(IPlayerMovable _playerMovable)
        {
            _playerMovable.OnMovementChanged += HandleNewMovement;
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
                case MovementType.Dash:
                    playerAnimator.SetBool("isJumped", true);
                    playerAnimator.SetTrigger("Jump");
                    backTrail.emitting = true;
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
                case MovementType.Dash:
                    playerAnimator.SetBool("isJumped", false);
                    backTrail.emitting = false;
                    break;
            }
        }
    }
}
