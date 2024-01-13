using UnityEngine;
using UnityEngine.AddressableAssets;

namespace SevenDwarfs.Sound
{
    public static class SoundUtility
    {
        /// <summary>
        /// SoundControllerをprefabとしてロードする
        /// 重複チェックをしないのと、AudioListenerはMainCameraあたりが持っている想定になっているので注意
        /// </summary>
        /// <returns></returns>
        public static SoundController LoadSoundController()
        {
            var op = Addressables.LoadAssetAsync<GameObject>("Assets/SevenDwarfs/Prefabs/Sound/SoundController.prefab");
            var prefab = op.WaitForCompletion();
            Addressables.Release(op);

            var controller = UnityEngine.Object.Instantiate(prefab);
            return controller.GetComponent<SoundController>();
        }
    }
}