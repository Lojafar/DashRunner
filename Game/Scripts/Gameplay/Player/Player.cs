using Game.Gameplay.Player.Input;
using Game.Gameplay.Player.Movement;
using UnityEngine;
using Zenject;
namespace Game.Gameplay.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Player : MonoBehaviour, IInitializable
    {
        IPlayerMovable playerMovable;
        IGameInput gameInput;
        [SerializeField] Transform feetTransform;
        public Vector3 FeetPosition => feetTransform.position;
        [field: SerializeField] public Transform PlayerTransfrom { get; private set; }
        [field: SerializeField] public Transform FrontTransform { get; private set; }
        [field: SerializeField] public Rigidbody2D PlayerRigidBody { get; private set; }
        [field: SerializeField] public Animator PlayerAnimator { get; private set; }
        public bool IsFliped { get; private set; }
        public float speed;
        public float jumpforce;
        public float dashDuration;
        public float dashForce;
        [Inject]
        public void Construct(IPlayerMovable _playerMovable, IGameInput _gameInput)
        {
            gameInput = _gameInput;
            playerMovable = _playerMovable;
        }
        public void Initialize()
        {
            gameInput.OnJumpInput += playerMovable.Jump;
            gameInput.OnExtraInput += playerMovable.Extra;
        }
        private void OnDestroy()
        {
            gameInput.OnJumpInput -= playerMovable.Jump;
            gameInput.OnExtraInput -= playerMovable.Extra;
        }
        private void Update()
        {
            playerMovable.Move(gameInput.GetHorizontalInput());
        }
        public void Flip()
        {
            IsFliped = !IsFliped;
            int rotY = IsFliped ? 180 : 0;
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, rotY, transform.eulerAngles.z);
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            playerMovable.HandleCollisionStart(collision);
        }
    }
}
