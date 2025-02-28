using Game.Root.Data;
using Game.Utils;
using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using LogType = Game.Utils.LogType;

namespace Game.Root.SaveLoad
{
    class PrefsSaverLoader : ISaverLoader
    {
        const string progressKey = "PlayerProgress";
        const string settingsKey = "Settings";
        public async UniTask<ProgressData> LoadProgress()
        {
            if (!PlayerPrefs.HasKey(progressKey))
            {
                return null;
            }
            else
            {
                string loadedJson = PlayerPrefs.GetString(progressKey);
                ProgressData progress = await Deserialize<ProgressData>(loadedJson);
                return progress;
            }
        }
        public async UniTask<SettingsData> LoadSettings()
        {
            if (!PlayerPrefs.HasKey(settingsKey))
            {
                return null;
            }
            else
            {
                string loadedJson = PlayerPrefs.GetString(settingsKey);
                SettingsData settings = await Deserialize<SettingsData>(loadedJson);
                return settings;
            }
        }
        async UniTask<T> Deserialize<T>(string jsonObj) where T : class
        {
            T result = null;
            await UniTask.RunOnThreadPool(() =>
            {
                try
                {
                    result = JsonUtility.FromJson<T>(jsonObj);
                }
                catch (Exception ex)
                {
                    DebugUtil.Log("Exception on deserialization of type: " + typeof(T) + ". Ex is: " + ex, LogType.Error);
                };
            });
            return result;
        }
        public async UniTask SaveProgress(ProgressData progress)
        {
            string jsonObj = await Serialize(progress);
            PlayerPrefs.SetString(progressKey, jsonObj);
            PlayerPrefs.Save();
        }
        public async UniTask SaveSettings(SettingsData settings)
        {
            string jsonObj = await Serialize(settings);
            PlayerPrefs.SetString(settingsKey, jsonObj);
            PlayerPrefs.Save();
        }
        async UniTask<string> Serialize<T>(T obj)
        {
            string result = "";
            await UniTask.RunOnThreadPool(() =>
            {
                try
                {
                    result = JsonUtility.ToJson(obj);
                }
                catch (Exception ex)
                {
                    DebugUtil.Log("Exception on serialization of type: " + typeof(T) + ". Ex is: " + ex, LogType.Error);
                };
            });
            return result;
        }
    }
}
