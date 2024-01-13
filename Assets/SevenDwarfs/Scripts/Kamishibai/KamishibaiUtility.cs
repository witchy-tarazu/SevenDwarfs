namespace SevenDwarfs.Kamishibai
{
    public static class KamishibaiUtility
    {
        /// <summary>
        /// Kamishibaiをprefabとしてロードする
        /// EventSystemがないと動かないので注意
        /// </summary>
        /// <returns></returns>
        public static KamishibaiController LoadKamishibai()
        {
            return SevenDwarfsResource.LoadAndInstantiate<KamishibaiController>("Assets/SevenDwarfs/Prefabs/Kamishibai/KamishibaiCanvas.prefab");
        }
    }
}