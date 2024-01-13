using System.Collections.Generic;
using UnityEngine;

namespace SevenDwarfs.MasterData
{
    /// <summary>
    /// 圧縮マスターデータ用ScriptableObjectの基底クラス
    /// MasterDataRecordBaseのサブクラスのListをフィールドに持たせる
    /// </summary>
    public abstract class MasterDataBase : ScriptableObject
    {
        /// <summary>
        /// データリストを設定
        /// </summary>
        public abstract void SetDataList(List<MasterRecordBase> dataList);
    }
}