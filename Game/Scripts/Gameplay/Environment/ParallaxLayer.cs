using UnityEngine;
namespace Game.Gameplay.Environment.BackGround
{
    public class ParallaxLayer : MonoBehaviour
    {
        Transform cameraTransform;
        [SerializeField] SpriteRenderer spriteRanderer;
        float startPosX;
        float effectStrength;
        public const float LayerLength = 19.2f;
        public void Init(LayerData _layerData, int _layerOrder, float _effectStrength)
        {
            spriteRanderer.sprite = _layerData.LayerSprite;
            spriteRanderer.sortingOrder = _layerOrder;
            spriteRanderer.transform.position = transform.position + _layerData.LocalOffset;
            effectStrength = _effectStrength;
        }
        private void Awake()
        {
            cameraTransform = Camera.main.transform;
            startPosX = transform.position.x;
        }
        void Update()
        {
            float temp = cameraTransform.position.x * (1 - effectStrength);
            float dist = cameraTransform.position.x * effectStrength;

            transform.position = new Vector3(startPosX + dist, transform.position.y, transform.position.z);

            if (temp > startPosX + (BackGround.AdditionalParts + 1) * LayerLength)
            {
                startPosX += (BackGround.AdditionalParts * 2 + 1) * LayerLength;
            }
            else if (temp < startPosX - (BackGround.AdditionalParts + 1) * LayerLength)
            {
                startPosX -= (BackGround.AdditionalParts * 2 + 1) * LayerLength;
            }
        }
    }
}