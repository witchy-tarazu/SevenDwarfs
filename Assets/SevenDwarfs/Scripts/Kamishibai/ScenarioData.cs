using System;

namespace SevenDwarfs.Kamishibai
{
    [Serializable]
    public class ScenarioData
    {
        /// <summary>���̓^�C�v</summary>
        public TextType textType;

        /// <summary>�L������</summary>
        public string characterName;

        /// <summary>���̓^�C�v</summary>
        public Position position;

        /// <summary>�\��</summary>
        public string facialExpression;

        /// <summary>�e�L�X�g</summary>
        public string text;
    }
}