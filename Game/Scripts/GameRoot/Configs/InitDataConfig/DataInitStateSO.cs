﻿using UnityEngine;

namespace Game.Root.Data.Initial
{
    [CreateAssetMenu(fileName = "InitialState", menuName = "ScriptableObjs/InitialData")]
    class DataInitStateSO : ScriptableObject
    {
        [field: SerializeField] public ProgressData InitialProgress { get; private set; }
        [field: SerializeField] public SettingsData InitialSettings { get; private set; }
    }
}
