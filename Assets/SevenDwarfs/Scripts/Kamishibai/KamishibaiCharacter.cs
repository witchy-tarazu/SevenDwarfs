using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AddressableAssets;
using UnityEngine.Assertions;

namespace SevenDwarfs.Kamishibai
{
    /// <summary>
    /// キャラ表示用コンポーネント
    /// </summary>
    public class KamishibaiCharacter : MonoBehaviour
    {
        [SerializeField]
        private Image image;
        [SerializeField]
        private RectTransform rectTransform;
        [SerializeField]
        private Canvas canvas;

        /// <summary>設定位置の辞書、Immutableが使えないのでこれで</summary>
        private static readonly Dictionary<Position, float> positonDictionary = new()
        {
            { Position.Left, -300f },
            { Position.Center, 0f },
            { Position.Right, 300f },
        };

        /// <summary>キャラクター名、この単位で管理される</summary>
        private string characterName;
        /// <summary>キャラクター位置</summary>
        private Position position;

        private Action<KamishibaiCharacter> onDuplicatedPosition;

        /// <summary>
        /// キャラクター情報をセット
        /// </summary>
        /// <param name="scenarioData"></param>
        public void SetCharacter(ScenarioData scenarioData, Action<KamishibaiCharacter> onDuplicatedPosition)
        {
            characterName = scenarioData.characterName;
            this.onDuplicatedPosition = onDuplicatedPosition;
        }

        /// <summary>
        /// 表示の更新処理
        /// </summary>
        /// <param name="scenarioData"></param>
        public void UpdateCharacter(ScenarioData scenarioData)
        {
            if (scenarioData.textType == TextType.Narration)
            {
                image.color = Color.gray;
                return;
            }

            // [キャラ名]_[表情]で取得
            string resourceName = string.Format("Assets/SevenDwarfs/Data/Kamishibai/Character/{0}_{1}.png", characterName, scenarioData.facialExpression);

            // ロードして設定
            var op = Addressables.LoadAssetAsync<Sprite>(resourceName);
            var sprite = op.WaitForCompletion();
            Assert.IsNotNull(sprite, string.Format("ロードしようとした{0}が見つからないか、データ形式に誤りがあります。:", resourceName));
            image.sprite = sprite;
            Addressables.Release(op);

            image.color = Color.white;
            canvas.sortingOrder = 10001;

            // キャラ個別指定の場合のみ位置と非アクティブ状態を設定
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