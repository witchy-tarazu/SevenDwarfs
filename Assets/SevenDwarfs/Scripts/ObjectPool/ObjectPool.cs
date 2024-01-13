using System;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Assertions;
using UnityEngine.Pool;

/// <summary>
/// 標準ObjectPoolの簡略化Wrapper
/// 上限だけ書いてもらって、他の処理は共通処理扱いにする
/// </summary>
namespace SevenDwarfs.ObjectPool
{
    public enum ResouceManagementType
    {
        Resources,
        Addressables,
    }

    public class ObjectPool<T> where T : MonoBehaviour
    {
        private IObjectPool<T> pool;
        private GameObject originalPrefab;

        public ObjectPool(string resourceKey, ResouceManagementType managementType, Transform parent, int capacity)
        {
            // オリジナルリソースの読み込み
            // ゲームジャム用なのでResouces.Loadからも拾えるようにしておく
            switch (managementType)
            {
                case ResouceManagementType.Resources:
                    {
                        originalPrefab = Resources.Load<GameObject>(resourceKey);
                    }
                    break;
                case ResouceManagementType.Addressables:
                    {
                        var op = Addressables.LoadAssetAsync<GameObject>(resourceKey);
                        originalPrefab = op.WaitForCompletion();
                        Addressables.Release(op);
                    }
                    break;
            }

            Assert.IsNotNull(originalPrefab, "量産元のPrefabのロードに失敗しました。");

            Func<T> createFunc = () =>
            {
                var spawnObject = UnityEngine.Object.Instantiate(originalPrefab, parent);
                Assert.IsNotNull(spawnObject, "生成しようとしているオブジェクトがnullです。");

                return spawnObject.GetComponent<T>();
            };

            pool = new UnityEngine.Pool.ObjectPool<T>(
                createFunc: createFunc,
                actionOnGet: (got) => { got.gameObject.SetActive(true); },
                actionOnRelease: (released) => { released.gameObject.SetActive(false); },
                actionOnDestroy: (destroyed) => { UnityEngine.Object.Destroy(destroyed); },
                collectionCheck: true,
                defaultCapacity: capacity,
                maxSize: capacity
             );
        }

        public T Get()
        {
            return pool.Get();
        }

        public void Return(T returnedObject)
        {
            pool.Release(returnedObject);
        }

        public void Clear()
        {
            pool.Clear();
        }
    }
}
