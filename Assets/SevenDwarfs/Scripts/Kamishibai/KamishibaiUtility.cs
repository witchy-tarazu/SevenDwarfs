namespace SevenDwarfs.Kamishibai
{
    public static class KamishibaiUtility
    {
        /// <summary>
        /// Kamishibai��prefab�Ƃ��ă��[�h����
        /// EventSystem���Ȃ��Ɠ����Ȃ��̂Œ���
        /// </summary>
        /// <returns></returns>
        public static KamishibaiController LoadKamishibai()
        {
            return SevenDwarfsResource.LoadAndInstantiate<KamishibaiController>("Assets/SevenDwarfs/Prefabs/Kamishibai/KamishibaiCanvas.prefab");
        }
    }
}