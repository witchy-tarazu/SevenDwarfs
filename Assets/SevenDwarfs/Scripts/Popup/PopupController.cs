using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System;

namespace SevenDwarfs.Popup
{
    /// <summary>
    /// ポップアップダイアログ制御
    /// </summary>
    public class PopupController : MonoBehaviour
    {
        /// <summary>背景画像</summary>
        [SerializeField]
        private Image backgroundImage;

        /// <summary>本文</summary>
        [SerializeField]
        private TextMeshProUGUI textMesh;

        [SerializeField]
        private Animator animator;

        /// <summary>閉じた際に実行されるAction</summary>
        private Action onCloseAction;

        /// <summary>
        /// 開く処理
        /// </summary>
        /// <param name="text"></param>
        /// <param name="onCloseAction"></param>
        public void Open(string text, Action onCloseAction = null)
        {
            textMesh.text = text;
            this.onCloseAction = onCloseAction;

            animator.Play("Open");
        }

        /// <summary>
        /// 開く処理
        /// 画像を差し替えるオーバーロード
        /// </summary>
        /// <param name="bgSpritePath"></param>
        /// <param name="onCloseAction"></param>
        public void Open(string text, string bgSpritePath, Action onCloseAction)
        {
            backgroundImage.sprite = SevenDwarfsResource.Load<Sprite>(string.Format("Assets/SevenDwarfs/Data/Popup/{0}.png", bgSpritePath));
            Open(text, onCloseAction);
        }

        /// <summary>
        /// 閉じるボタン押下時のコールバック
        /// </summary>
        public void OnClickClose()
        {
            animator.Play("Close");
        }

        /// <summary>
        /// 閉じた時のコールバック
        /// アニメーションから呼び出している
        /// </summary>
        public void OnClose()
        {
            onCloseAction.Invoke();
        }
    }
}
