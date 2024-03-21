using UnityEngine.AddressableAssets;
using UnityEngine.Assertions;
using UnityEngine;

namespace SevenDwarfs
{
    public static class SevenDwarfsResource
    {
        /// <summary>
        /// 同期ロード
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path"></param>
        /// <returns></returns>
        public static T Load<T>(string path) where T : class
        {
            var op = Addressables.LoadAssetAsync<T>(path);
            var asset = op.WaitForCompletion();
            Assert.IsNotNull(asset, string.Format("ロードしようとした{0}が見つからないか、データ形式に誤りがあります。:", path));
            
            // TODO: 監視してなくなった削除するようにする
            // Addressables.Release(op);

            return asset;
        }


        /// <summary>
        /// 同期Instantiate
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="parent"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public static T LoadAndInstantiate<T>(Transform parent, string path) where T : MonoBehaviour
        {
            var prefab = Load<GameObject>(path);
            var gameObject = Object.Instantiate(prefab, parent);
            var component = gameObject.GetComponent<T>();
            Assert.IsNotNull(component, string.Format("ロードした{0}に{1}コンポーネントが見つかりませんでした。:", path, nameof(T)));

            return component;
        }
    }
}