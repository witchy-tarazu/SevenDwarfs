using System;
using System.Collections.Generic;

namespace SevenDwarfs.CrossingData
{
    /// <summary>
    /// 起動中の恒久データの管理クラス
    /// こちらはインスタンスをそのまま返す
    /// </summary>
    public sealed class PermanentDataManager
    {
        public Dictionary<Type, PermanentData> dataDictionary;

        public PermanentDataManager()
        {
            dataDictionary = new();
        }

        /// <summary>
        /// 初期化
        /// ソフトウェアリセット掛けるときは呼ぶ
        /// </summary>
        public void Reset()
        {
            dataDictionary.Clear();
        }

        /// <summary>
        /// 一時データの保管
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="permanentData"></param>
        public void Register<T>(T permanentData) where T : PermanentData
        {
            dataDictionary[typeof(T)] = permanentData;
        }

        /// <summary>
        /// ロード処理を実行
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="action"></param>
        /// <returns></returns>
        public T Load<T>() where T : PermanentData
        {
            if (dataDictionary.TryGetValue(typeof(T), out PermanentData permanentData))
            {
                return permanentData as T;
            }

            return null;
        }
    }
}
