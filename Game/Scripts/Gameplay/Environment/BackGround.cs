using UnityEngine;

namespace Game.Gameplay.Environment.BackGround
{
    public class BackGround : MonoBehaviour
    {
        [SerializeField] LayerData[] layers;
        [SerializeField] ParallaxLayer layerPrefab;
        const int NearLayerOrder = -10;
        public const int AdditionalParts = 1;
        const float MaxLayerEffect = 0.4f;
        private void Start()
        {
            Init(layers);
        }
        public void Init(LayerData[] layers)
        {
            float stepEffReduc = MaxLayerEffect / layers.Length;
            for (int i = 0; i < layers.Length; i++)
            {
                for (int partIndex = -AdditionalParts; partIndex <= AdditionalParts; partIndex++)
                {
                    ParallaxLayer spawnedLayer = Instantiate(layerPrefab, new Vector3(partIndex * ParallaxLayer.LayerLength + transform.position.x, transform.position.y, transform.position.z), Quaternion.identity, transform);
                    spawnedLayer.Init(layers[i], NearLayerOrder - i, MaxLayerEffect - stepEffReduc * i);
                }
            }
        }
    }
}
