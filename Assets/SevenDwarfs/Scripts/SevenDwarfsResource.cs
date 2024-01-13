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
            Addressables.Release(op);

            return asset;
        }

        /// <summary>
        /// 同期Instantiate
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static GameObject LoadAndInstantiate(string path)
        {
            var op = Addressables.InstantiateAsync(path);
            var gameObject = op.WaitForCompletion();
            Assert.IsNotNull(gameObject, string.Format("ロードしようとした{0}が見つからないか、データ形式に誤りがあります。:", path));
            Addressables.Release(op);

            return gameObject;
        }

        /// <summary>
        /// 同期Instantiate
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static T LoadAndInstantiate<T>(string path) where T : MonoBehaviour
        {
            var gameObject = LoadAndInstantiate(path);
            var component = gameObject.GetComponent<T>();
            Assert.IsNotNull(component, string.Format("ロードした{0}に{1}コンポーネントが見つかりませんでした。:", path, nameof(T)));

            return component;
        }
    }
}