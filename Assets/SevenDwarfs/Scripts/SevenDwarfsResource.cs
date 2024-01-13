using UnityEngine.AddressableAssets;
using UnityEngine.Assertions;
using UnityEngine;

namespace SevenDwarfs
{
    public static class SevenDwarfsResource
    {
        /// <summary>
        /// �������[�h
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path"></param>
        /// <returns></returns>
        public static T Load<T>(string path) where T : class
        {
            var op = Addressables.LoadAssetAsync<T>(path);
            var asset = op.WaitForCompletion();
            Assert.IsNotNull(asset, string.Format("���[�h���悤�Ƃ���{0}��������Ȃ����A�f�[�^�`���Ɍ�肪����܂��B:", path));
            Addressables.Release(op);

            return asset;
        }

        /// <summary>
        /// ����Instantiate
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static GameObject LoadAndInstantiate(string path)
        {
            var op = Addressables.InstantiateAsync(path);
            var gameObject = op.WaitForCompletion();
            Assert.IsNotNull(gameObject, string.Format("���[�h���悤�Ƃ���{0}��������Ȃ����A�f�[�^�`���Ɍ�肪����܂��B:", path));
            Addressables.Release(op);

            return gameObject;
        }

        /// <summary>
        /// ����Instantiate
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static T LoadAndInstantiate<T>(string path) where T : MonoBehaviour
        {
            var gameObject = LoadAndInstantiate(path);
            var component = gameObject.GetComponent<T>();
            Assert.IsNotNull(component, string.Format("���[�h����{0}��{1}�R���|�[�l���g��������܂���ł����B:", path, nameof(T)));

            return component;
        }
    }
}