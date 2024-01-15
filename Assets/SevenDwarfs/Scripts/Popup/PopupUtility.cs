using UnityEngine;
namespace SevenDwarfs.Popup
{
    public static class PopupUtility
    {
        /// <summary>
        /// PopupControllerをprefabとしてロードする
        /// EventSystemがSceneに必要なので注意
        /// </summary>
        /// <returns></returns>
        public static PopupController LoadPopupController(Transform parent)
        {
            return SevenDwarfsResource.LoadAndInstantiate<PopupController>(parent, "Assets/SevenDwarfs/Prefabs/Popup/PopupCanvas.prefab");
        }
    }
}