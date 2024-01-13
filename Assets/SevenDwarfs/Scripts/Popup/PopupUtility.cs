namespace SevenDwarfs.Popup
{
    public static class SoundUtility
    {
        /// <summary>
        /// PopupControllerをprefabとしてロードする
        /// EventSystemがSceneに必要なので注意
        /// </summary>
        /// <returns></returns>
        public static PopupController LoadPopupController()
        {
            return SevenDwarfsResource.LoadAndInstantiate<PopupController>("Assets/SevenDwarfs/Prefabs/Popup/PopupCanvas.prefab");
        }
    }
}