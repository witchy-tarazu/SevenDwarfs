namespace SevenDwarfs.MasterData
{
    /// <summary>
    /// レコードの実体
    /// Serializable属性を付与すること
    /// </summary>
    public abstract class MasterRecordBase
    {
        /// <summary>
        /// シャローコピーの実施
        /// </summary>
        /// <returns></returns>
        public MasterRecordBase SharrowCopy()
        {
            return MemberwiseClone() as MasterRecordBase;
        }
    }
}