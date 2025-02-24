using UnityEngine;
using Zenject;
namespace Game.Gameplay.Player.Camera
{
    using Camera = UnityEngine.Camera;
    class CameraFollower : MonoBehaviour, ICameraFollower
    {
        [SerializeField] float followSpeed;
        [SerializeField] Vector3 targetOffset;
        Transform cameraTransform;
        Transform targetTransform;
        [Inject]
        void Construct(Player _player)
        {
            targetTransform = _player.PlayerTransfrom;
        }
        private void Awake()
        {
            cameraTransform = Camera.main.transform;
        }
        private void FixedUpdate()
        {
            Follow();
        }
        public void Follow()
        {
            Vector3 lerpedPos = Vector3.Lerp(cameraTransform.position, targetTransform.position + targetOffset, Time.deltaTime * followSpeed);
            cameraTransform.position = new Vector3(lerpedPos.x, lerpedPos.y, cameraTransform.position.z);
        }
    }
}
