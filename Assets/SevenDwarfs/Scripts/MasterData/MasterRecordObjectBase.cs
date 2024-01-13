using UnityEngine;

namespace SevenDwarfs.MasterData
{
    /// <summary>
    /// マスターデータレコード用ScriptableObjectの基底クラス
    /// </summary>
    public abstract class MasterRecordObjectBase : ScriptableObject
    {
        /// <summary>
        /// レコード実体を取得
        /// </summary>
        /// <returns></returns>
        public abstract MasterRecordBase GetRecord();
    }
}