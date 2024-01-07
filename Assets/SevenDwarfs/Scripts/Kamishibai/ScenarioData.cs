using System;

namespace SevenDwarfs.Kamishibai
{
    [Serializable]
    public class ScenarioData
    {
        /// <summary>文章タイプ</summary>
        public TextType textType;

        /// <summary>キャラ名</summary>
        public string characterName;

        /// <summary>文章タイプ</summary>
        public Position position;

        /// <summary>表情</summary>
        public string facialExpression;

        /// <summary>テキスト</summary>
        public string text;
    }
}