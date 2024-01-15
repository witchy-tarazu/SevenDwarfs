using System;
using TMPro;
using UnityEngine;

namespace SevenDwarfs.Kamishibai
{
    /// <summary>
    /// 画像パチパチ切り替わる方式のADV
    /// EventSystemをSceneに配置したうえで使うこと
    /// </summary>
    public class KamishibaiController : MonoBehaviour
    {
        [SerializeField]
        private Transform adjustedBySafeAreaPanelTransform;

        [SerializeField]
        private Transform characterParentTransform;

        [SerializeField]
        private GameObject grayBackground;

        [SerializeField]
        private TextMeshProUGUI textMeshPro;

        private CharacterController characterController;
        private TextController textController;

        private ScenarioObject scenarioObject = null;
        private int scenarioIndex;
        private Action onFinishAction;

        /// <summary>
        /// 自身を非表示にする
        /// 最初に自身を非アクティブにしておくため
        /// </summary>
        public void Hide()
        {
            gameObject.SetActive(false);
        }

        /// <summary>
        /// シナリオデータの設定
        /// </summary>
        /// <param name="scenarioId"></param>
        public void Setup(int scenarioId, Action onFinishAction)
        {
            scenarioIndex = 0;
            this.onFinishAction = onFinishAction;

            // IDからシナリオのScriptableObjectを取得
            string resourceName = string.Format("Assets/SevenDwarfs/Data/Kamishibai/Scenario/Scenario{0}.asset", scenarioId);

            // ロードして設定
            scenarioObject = SevenDwarfsResource.Load<ScenarioObject>(resourceName);

            characterController = new(characterParentTransform);
            textController = new(textMeshPro);
            OnClick();
            gameObject.SetActive(true);
        }

        public void OnClick()
        {
            if (scenarioObject == null)
            {
                return;
            }

            ReadScenario();
            scenarioIndex++;
        }

        private void ReadScenario()
        {
            var scenarioDataList = scenarioObject.scenarioDataList;
            if (scenarioDataList.Count <= scenarioIndex)
            {
                CloseScenario();
                return;
            }

            var scenarioData = scenarioObject.scenarioDataList[scenarioIndex];
            characterController.ReadScenario(scenarioData);
            textController.ReadScenario(scenarioData);
        }

        /// <summary>
        /// シナリオ終了
        /// 一旦そのまま破棄にしているがフェードなどを考えても良い
        /// </summary>
        private void CloseScenario()
        {
            scenarioObject = null;
            characterController.Reset();
            gameObject.SetActive(false);

            onFinishAction.Invoke();
        }
    }
}
