using System;
using UnityEngine;
namespace Game.Gameplay.Environment.BackGround
{
    [Serializable]
    public class LayerData
    {
        [field: SerializeField] public Sprite LayerSprite { get; private set; }
        [field: SerializeField] public Vector3 LocalOffset { get; private set; }
    }
}
