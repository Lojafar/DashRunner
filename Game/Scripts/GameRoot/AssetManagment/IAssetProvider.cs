using System.Threading.Tasks;
using UnityEngine;
namespace Game.Root.AssetManagment
{
    public interface IAssetProvider
    {
        public Task<T> LoadPrefab<T>(string Key) where T : Object;
        public Task<T> LoadAsset<T>(string Key) where T : Object;
        public Task<T> LoadConfig<T>(string Key) where T : ScriptableObject;
    }
}
