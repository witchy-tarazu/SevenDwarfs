namespace SevenDwarfs.MasterData
{
    /// <summary>
    /// ���R�[�h�̎���
    /// Serializable������t�^���邱��
    /// </summary>
    public abstract class MasterRecordBase
    {
        /// <summary>
        /// �V�����[�R�s�[�̎��{
        /// </summary>
        /// <returns></returns>
        public MasterRecordBase SharrowCopy()
        {
            return MemberwiseClone() as MasterRecordBase;
        }
    }
}