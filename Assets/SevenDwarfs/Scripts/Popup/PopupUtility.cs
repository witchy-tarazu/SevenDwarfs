namespace SevenDwarfs.Popup
{
    public static class SoundUtility
    {
        /// <summary>
        /// PopupController��prefab�Ƃ��ă��[�h����
        /// EventSystem��Scene�ɕK�v�Ȃ̂Œ���
        /// </summary>
        /// <returns></returns>
        public static PopupController LoadPopupController()
        {
            return SevenDwarfsResource.LoadAndInstantiate<PopupController>("Assets/SevenDwarfs/Prefabs/Popup/PopupCanvas.prefab");
        }
    }
}