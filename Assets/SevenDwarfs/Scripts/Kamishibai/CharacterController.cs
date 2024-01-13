using SevenDwarfs.ObjectPool;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace SevenDwarfs.Kamishibai
{
    public class CharacterController
    {
        private Dictionary<string, KamishibaiCharacter> characterDictionary;
        private ObjectPool<KamishibaiCharacter> characterPool;

        public CharacterController(Transform parentTransform)
        {
            characterDictionary = new();
            characterPool = new("Assets/SevenDwarfs/Prefabs/Kamishibai/KamishibaiCharacter.prefab", ResouceManagementType.Addressables, parentTransform, 3);
        }

        public void ReadScenario(ScenarioData scenarioData)
        {
            if (scenarioData.textType == TextType.Character)
            {
                // �L�����N�^�[�̐V�K�o�ꎞ�̂ݎ����o�^�Ə���X�V���s��
                var characterName = scenarioData.characterName;
                if (!characterDictionary.ContainsKey(characterName))
                {
                    var newCharacter = characterPool.Get();
                    newCharacter.SetCharacter(scenarioData, OnDuplicatedPosition);
                    characterDictionary.Add(characterName, newCharacter);
                }
            }

            foreach (var (name, character) in characterDictionary)
            {
                character.UpdateCharacter(scenarioData);
            }
        }

        public void Reset()
        {
            characterDictionary.Clear();
            characterPool.Clear();
        }

        /// <summary>
        /// �ʒu���d�������炻�̃L����������
        /// </summary>
        /// <param name="duplicatedCharacter"></param>
        private void OnDuplicatedPosition(KamishibaiCharacter duplicatedCharacter)
        {
            characterPool.Return(duplicatedCharacter);
        }
    }
}