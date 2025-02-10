using UnityEngine;
namespace Game.Root.GameConfig
{
    [CreateAssetMenu(fileName = "GameConfig", menuName = "ScriptableObjs/GameConfig")]
    class GameConfigSO : ScriptableObject
    {
        [field: SerializeField] public GameConfig GameConfig { get; private set;}
    }
}
