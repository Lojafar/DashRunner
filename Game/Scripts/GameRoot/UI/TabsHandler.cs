using Game.Root.UI.Tabs;
using Game.Utils;
using System;
using System.Collections.Generic;

namespace Game.Root.UI
{
    public class TabsHandler
    {
        Type openedTabType;
        readonly Dictionary<Type, ITabModel> registeredModelsMap; 
        bool anyTabInAction = false;
        event Action OnTabFinished;
        public TabsHandler()
        {
            registeredModelsMap = new Dictionary<Type, ITabModel>();
        }
        public void RegisterTabModel<T>(T tabModel) where T : ITabModel
        {
            Type tabType = typeof(T);
            if (!registeredModelsMap.ContainsKey(tabType))
            {
                registeredModelsMap.Add(tabType, tabModel);
                tabModel.Close(null);
            }
            else
            {
                DebugUtil.Log("The model with type " + tabType + " is already registered", LogType.Warning);
            }
        }
        public void OpenTab<T>() where T : ITabModel
        {
            OpenTab(typeof(T));
        }
        public void OpenTab(Type tabType) 
        {
            if (!registeredModelsMap.ContainsKey(tabType))
            {
                DebugUtil.Log("The model with type " + tabType + " is not registered", LogType.Warning);
                return;
            }
            if (anyTabInAction)
            {
               OnTabFinished += () => OnOpenEvent(tabType);
               return;
            }
            if (openedTabType != null)
            {
                OnTabFinished += () => OnOpenEvent(tabType);
                CloseTab(openedTabType);
                return;
            }

            OnTabFinished = null;
            anyTabInAction = true;
            openedTabType = tabType;
            registeredModelsMap[tabType].Open(() => OnTabCompleted());
        }
        void OnOpenEvent(Type tabType)
        {
            OpenTab(tabType);
        }
        public void CloseTab<T>() where T : ITabModel
        {
            CloseTab(typeof(T));
        }
        public void CloseTab(Type tabType)
        {
            if (!registeredModelsMap.ContainsKey(tabType))
            {
                DebugUtil.Log("The model with type " + tabType + " is not registered", LogType.Warning);
                return;
            }
            if (anyTabInAction)
            {
                OnTabFinished += () => OnCloseEvent(tabType);
                return;
            }
            anyTabInAction = true;
            openedTabType = null;
            registeredModelsMap[tabType].Close(() => OnTabCompleted());
        }
        void OnCloseEvent(Type tabType)
        {
            OpenTab(tabType);
        }
        void OnTabCompleted()
        {
            anyTabInAction = false;
            OnTabFinished?.Invoke();
            OnTabFinished = null;
        }
    }
}
