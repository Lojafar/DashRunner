using System;
using System.Collections;
using UnityEngine;
namespace Game.Gameplay.Player.Movement
{
    class DefaultPlayerMovable : IPlayerMovable
    {
        public event Action<MovementType> OnMovementChanged;
        readonly Player player;
        readonly Rigidbody2D playerRb;
        readonly float speed = 10;
        readonly float jumpForce = 10;
        readonly static LayerMask groundLayerMask = LayerMask.GetMask("Ground");
        bool isMoving;
        bool isDashing;
        bool canJump;
        public DefaultPlayerMovable(Player _player)
        {
            player = _player;
            playerRb = _player.PlayerRigidBody;
        }
        public void Extra()
        {
            if (isDashing) return;
            player.StartCoroutine(DashRoutine());
        }
        IEnumerator DashRoutine()
        {
            isDashing = true;
            float grav = playerRb.gravityScale;
            playerRb.gravityScale = 0;
            int dir = player.IsFliped ? -1 : 1;
            playerRb.velocity = new Vector3(dir * Time.fixedDeltaTime * player.dashForce, 0, 0);
            yield return new WaitForSeconds(player.dashDuration);
            playerRb.velocity = Vector3.zero;
            playerRb.gravityScale = grav;
            isDashing = false;
        }
        public void Jump()
        {
            if (!canJump) return;
            playerRb.AddForce(Vector2.up * player.jumpforce, ForceMode2D.Impulse);
            OnMovementChanged?.Invoke(MovementType.Jump);
            canJump = false;
        }
        public void Move(float direction)
        {
            if (isDashing) return;
            if (direction > 0 && player.IsFliped || direction < 0 && !player.IsFliped)
            {
                player.Flip();
            }
            if (canJump && ((direction > 0 || direction < 0) && !isMoving || Mathf.Approximately(0, direction) && isMoving))
            {
                isMoving = !isMoving;
                MovementType movementType = isMoving ? MovementType.Running : MovementType.Standing;
                OnMovementChanged?.Invoke(movementType);
            }
            playerRb.velocity = new Vector3(direction * player.speed * Time.fixedDeltaTime, playerRb.velocity.y, 0);
        }
        public void HandleCollisionStart(Collision2D collision)
        {
            if (Physics2D.Raycast(player.FeetPosition, Vector2.down, 0.1f, groundLayerMask))
            {
                OnMovementChanged?.Invoke(isMoving ? MovementType.Running : MovementType.Standing);
                canJump = true;
            }
        }
    }
}
