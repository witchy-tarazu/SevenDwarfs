using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AddressableAssets;
using UnityEngine.Assertions;

namespace SevenDwarfs.Kamishibai
{
    /// <summary>
    /// �L�����\���p�R���|�[�l���g
    /// </summary>
    public class KamishibaiCharacter : MonoBehaviour
    {
        [SerializeField]
        private Image image;
        [SerializeField]
        private RectTransform rectTransform;
        [SerializeField]
        private Canvas canvas;

        /// <summary>�ݒ�ʒu�̎����AImmutable���g���Ȃ��̂ł����</summary>
        private static readonly Dictionary<Position, float> positonDictionary = new()
        {
            { Position.Left, -300f },
            { Position.Center, 0f },
            { Position.Right, 300f },
        };

        /// <summary>�L�����N�^�[���A���̒P�ʂŊǗ������</summary>
        private string characterName;
        /// <summary>�L�����N�^�[�ʒu</summary>
        private Position position;

        private Action<KamishibaiCharacter> onDuplicatedPosition;

        /// <summary>
        /// �L�����N�^�[�����Z�b�g
        /// </summary>
        /// <param name="scenarioData"></param>
        public void SetCharacter(ScenarioData scenarioData, Action<KamishibaiCharacter> onDuplicatedPosition)
        {
            characterName = scenarioData.characterName;
            this.onDuplicatedPosition = onDuplicatedPosition;
        }

        /// <summary>
        /// �\���̍X�V����
        /// </summary>
        /// <param name="scenarioData"></param>
        public void UpdateCharacter(ScenarioData scenarioData)
        {
            if (scenarioData.textType == TextType.Narration)
            {
                image.color = Color.gray;
                return;
            }

            // [�L������]_[�\��]�Ŏ擾
            string resourceName = string.Format("Assets/SevenDwarfs/Data/Kamishibai/Character/{0}_{1}.png", characterName, scenarioData.facialExpression);

            // ���[�h���Đݒ�
            var op = Addressables.LoadAssetAsync<Sprite>(resourceName);
            var sprite = op.WaitForCompletion();
            Assert.IsNotNull(sprite, string.Format("���[�h���悤�Ƃ���{0}��������Ȃ����A�f�[�^�`���Ɍ�肪����܂��B:", resourceName));
            image.sprite = sprite;
            Addressables.Release(op);

            image.color = Color.white;
            canvas.sortingOrder = 10001;

            // �L�����ʎw��̏ꍇ�݈̂ʒu�Ɣ�A�N�e�B�u��Ԃ�ݒ�
            if (scenarioData.textType == TextType.Character)
            {
                if (scenarioData.characterName == characterName)
                {
                    position = scenarioData.position;
                    rectTransform.anchoredPosition = new(positonDictionary[position], 0);
                }
                else if (position == scenarioData.position)
                {
                    onDuplicatedPosition.Invoke(this);
                }
                else
                {
                    image.color = Color.gray;
                    canvas.sortingOrder = 10000;
                }
            }
        }
    }
}