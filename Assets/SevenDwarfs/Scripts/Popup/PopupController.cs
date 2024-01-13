using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System;

namespace SevenDwarfs.Popup
{
    /// <summary>
    /// �|�b�v�A�b�v�_�C�A���O����
    /// </summary>
    public class PopupController : MonoBehaviour
    {
        /// <summary>�w�i�摜</summary>
        [SerializeField]
        private Image backgroundImage;

        /// <summary>�{��</summary>
        [SerializeField]
        private TextMeshProUGUI textMesh;

        [SerializeField]
        private Animator animator;

        /// <summary>�����ۂɎ��s�����Action</summary>
        private Action onCloseAction;

        /// <summary>
        /// �J������
        /// </summary>
        /// <param name="onCloseAction"></param>
        public void Open(string text, Action onCloseAction)
        {
            textMesh.text = text;
            this.onCloseAction = onCloseAction;

            animator.Play("Open");
        }

        /// <summary>
        /// �J������
        /// �摜�������ւ���I�[�o�[���[�h
        /// </summary>
        /// <param name="bgSpritePath"></param>
        /// <param name="onCloseAction"></param>
        public void Open(string text, string bgSpritePath, Action onCloseAction)
        {
            backgroundImage.sprite = SevenDwarfsResource.Load<Sprite>(bgSpritePath);
            Open(text, onCloseAction);
        }

        /// <summary>
        /// ����{�^���������̃R�[���o�b�N
        /// </summary>
        public void OnClickClose()
        {
            animator.Play("Close");
        }

        /// <summary>
        /// �������̃R�[���o�b�N
        /// �A�j���[�V��������Ăяo���Ă���
        /// </summary>
        public void OnClose()
        {
            onCloseAction.Invoke();
        }
    }
}
