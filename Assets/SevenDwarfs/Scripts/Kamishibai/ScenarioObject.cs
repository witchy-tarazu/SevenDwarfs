using System.Collections.Generic;
using UnityEngine;

namespace SevenDwarfs.Kamishibai
{
    [CreateAssetMenu(fileName = "Scenario", menuName = "SevenDwarfs/Kamishibai/ScenarioObject")]
    public class ScenarioObject : ScriptableObject
    {
        public List<ScenarioData> scenarioDataList;
    }
}