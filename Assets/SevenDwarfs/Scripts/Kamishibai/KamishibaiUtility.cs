namespace SevenDwarfs.Kamishibai
{
    public static class KamishibaiUtility
    {
        /// <summary>
        /// Kamishibai‚ğprefab‚Æ‚µ‚Äƒ[ƒh‚·‚é
        /// EventSystem‚ª‚È‚¢‚Æ“®‚©‚È‚¢‚Ì‚Å’ˆÓ
        /// </summary>
        /// <returns></returns>
        public static KamishibaiController LoadKamishibai()
        {
            return SevenDwarfsResource.LoadAndInstantiate<KamishibaiController>("Assets/SevenDwarfs/Prefabs/Kamishibai/KamishibaiCanvas.prefab");
        }
    }
}