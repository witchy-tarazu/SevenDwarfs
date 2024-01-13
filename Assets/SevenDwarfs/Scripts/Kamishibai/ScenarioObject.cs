using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace SevenDwarfs.Kamishibai
{
    [CreateAssetMenu(fileName = "Scenario", menuName = "ScriptableObjects/Kamishibai/ScenarioObject")]
    public class ScenarioObject : ScriptableObject
    {
        public List<ScenarioData> scenarioDataList;
    }
}