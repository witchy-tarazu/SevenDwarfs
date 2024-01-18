using System;
using TMPro;
using UnityEngine;

namespace SevenDwarfs.Kamishibai
{
    /// <summary>
    /// �摜�p�`�p�`�؂�ւ�������ADV
    /// EventSystem��Scene�ɔz�u���������Ŏg������
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
        private Action onClickAction;

        /// <summary>
        /// ���g���\���ɂ���
        /// �ŏ��Ɏ��g���A�N�e�B�u�ɂ��Ă�������
        /// </summary>
        public void Hide()
        {
            gameObject.SetActive(false);
        }

        /// <summary>
        /// �V�i���I�f�[�^�̐ݒ�
        /// </summary>
        /// <param name="scenarioId"></param>
        /// <param name="onFinishAction"></param>
        /// <param name="onClickAction"></param>
        public void Setup(int scenarioId, Action onFinishAction = null, Action onClickAction = null)
        {
            scenarioIndex = 0;
            this.onFinishAction = onFinishAction;
            this.onClickAction = onClickAction;

            // ID����V�i���I��ScriptableObject���擾
            string resourceName = string.Format("Assets/SevenDwarfs/Data/Kamishibai/Scenario/Scenario{0}.asset", scenarioId);

            // ���[�h���Đݒ�
            scenarioObject = SevenDwarfsResource.Load<ScenarioObject>(resourceName);

            characterController = new(characterParentTransform);
            textController = new(textMeshPro);

            ReadScenario();
            gameObject.SetActive(true);
        }

        public void OnClick()
        {
            if (scenarioObject == null)
            {
                return;
            }

            onClickAction?.Invoke();
            ReadScenario();
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
            scenarioIndex++;
        }

        /// <summary>
        /// �V�i���I�I��
        /// ��U���̂܂ܔj���ɂ��Ă��邪�t�F�[�h�Ȃǂ��l���Ă��ǂ�
        /// </summary>
        private void CloseScenario()
        {
            scenarioObject = null;
            characterController.Reset();
            gameObject.SetActive(false);

            onFinishAction?.Invoke();
        }
    }
}
