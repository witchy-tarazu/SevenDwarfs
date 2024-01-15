using UnityEngine;
namespace SevenDwarfs.Sound
{
    public static class SoundUtility
    {
        /// <summary>
        /// SoundControllerをprefabとしてロードする
        /// 重複チェックをしないのと、AudioListenerはMainCameraあたりが持っている想定になっているので注意
        /// </summary>
        /// <returns></returns>
        public static SoundController LoadSoundController(Transform parent)
        {
            return SevenDwarfsResource.LoadAndInstantiate<SoundController>(parent, "Assets/SevenDwarfs/Prefabs/Sound/SoundController.prefab");
        }
    }
}