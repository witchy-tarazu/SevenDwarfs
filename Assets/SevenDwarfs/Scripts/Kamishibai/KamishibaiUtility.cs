using UnityEngine;
using UnityEngine.AddressableAssets;

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
            var op = Addressables.LoadAssetAsync<GameObject>("Assets/SevenDwarfs/Prefabs/Kamishibai/KamishibaiCanvas.prefab");
            var prefab = op.WaitForCompletion();
            Addressables.Release(op);

            var controller = UnityEngine.Object.Instantiate(prefab);
            return controller.GetComponent<KamishibaiController>();
        }
    }
}