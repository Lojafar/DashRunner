using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Game.Root.AssetManagment
{
    class ResourcesAssetProvider : IAssetProvider
    {
        readonly Dictionary<string, object> loadedPrefabsMap;
        const string prefabsPathPattern = "Prefabs/{0}";
        const string assetsPathPattern = "Assets/{0}";
        const string configsPathPattern = "Configs/{0}";
        public ResourcesAssetProvider()
        {
            loadedPrefabsMap = new();
        }
        public async UniTask<T> LoadPrefab<T>(string Key) where T : Object
        {
            if(loadedPrefabsMap.TryGetValue(Key, out object asset))
            {
                return (T)asset;
            }

            T loadedAsset = (T)(await Resources.LoadAsync<T>(string.Format(prefabsPathPattern, Key)));

            if (!loadedPrefabsMap.ContainsKey(Key))
            {
                loadedPrefabsMap.Add(Key, loadedAsset);
            }
           
            return loadedAsset;
        }
        public async UniTask<T> LoadAsset<T>(string Key) where T : Object
        {
            T loadedAsset = (T) (await Resources.LoadAsync<T>(string.Format(assetsPathPattern, Key)));
            return loadedAsset;
        }
        public async UniTask<T> LoadConfig<T>(string Key) where T : ScriptableObject
        {
            T loadedAsset = (T) (await Resources.LoadAsync<T>(string.Format(configsPathPattern, Key)));
            return loadedAsset;
        }
    }
}
