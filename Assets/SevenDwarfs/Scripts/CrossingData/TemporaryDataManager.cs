using System;
using System.Collections.Generic;

namespace SevenDwarfs.CrossingData
{
    /// <summary>
    /// 受け渡しのために一時的に使用するデータの管理クラス
    /// 使い切りなのでデータを入れた後にロードするとデータが消えるのは注意
    /// </summary>
    public sealed class TemporaryDataManager
    {
        public Dictionary<Type, TemporaryData> dataDictionary;

        public TemporaryDataManager()
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
        /// <param name="temporaryData"></param>
        public void Register<T>(T temporaryData) where T : TemporaryData
        {
            dataDictionary[typeof(T)] = temporaryData;
        }

        /// <summary>
        /// 一時データの受け取り処理を実行
        /// 使い切り
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="action"></param>
        /// <returns></returns>
        public bool TryToReceive<T>(Action<T> action) where T : TemporaryData
        {
            if (dataDictionary.TryGetValue(typeof(T), out TemporaryData temporaryData))
            {
                if (temporaryData.CanReceive())
                {
                    action.Invoke(temporaryData as T);
                    temporaryData.Unload();
                    return true;
                }
            }

            return false;
        }
    }
}
