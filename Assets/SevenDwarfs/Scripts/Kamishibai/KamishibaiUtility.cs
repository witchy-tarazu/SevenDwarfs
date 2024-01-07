using UnityEngine;
using UnityEngine.AddressableAssets;

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
            var op = Addressables.LoadAssetAsync<GameObject>("Assets/SevenDwarfs/Prefabs/Kamishibai/KamishibaiCanvas.prefab");
            var prefab = op.WaitForCompletion();
            Addressables.Release(op);

            var controller = UnityEngine.Object.Instantiate(prefab);
            return controller.GetComponent<KamishibaiController>();
        }
    }
}