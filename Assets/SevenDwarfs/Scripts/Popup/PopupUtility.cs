using UnityEngine;
namespace SevenDwarfs.Popup
{
    public static class PopupUtility
    {
        /// <summary>
        /// PopupController��prefab�Ƃ��ă��[�h����
        /// EventSystem��Scene�ɕK�v�Ȃ̂Œ���
        /// </summary>
        /// <returns></returns>
        public static PopupController LoadPopupController(Transform parent)
        {
            return SevenDwarfsResource.LoadAndInstantiate<PopupController>(parent, "Assets/SevenDwarfs/Prefabs/Popup/PopupCanvas.prefab");
        }
    }
}