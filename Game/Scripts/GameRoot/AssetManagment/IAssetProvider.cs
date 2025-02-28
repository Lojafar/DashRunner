using Cysharp.Threading.Tasks;
using UnityEngine;
namespace Game.Root.AssetManagment
{
    public interface IAssetProvider
    {
        public UniTask<T> LoadPrefab<T>(string Key) where T : Object;
        public UniTask<T> LoadAsset<T>(string Key) where T : Object;
        public UniTask<T> LoadConfig<T>(string Key) where T : ScriptableObject;
    }
}
