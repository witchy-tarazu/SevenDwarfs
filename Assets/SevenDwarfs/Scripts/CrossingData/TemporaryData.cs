namespace SevenDwarfs.CrossingData
{
    /// <summary>
    /// �󂯓n���̂��߂Ɉꎞ�I�Ɏg�p����f�[�^
    /// ��x�󂯓n������������g��Ȃ����̂͂�����p��
    /// </summary>
    public abstract class TemporaryData : CrossingDataBase
    {
        private enum State
        {
            Unavailable,
            Available,
        }

        private State state = State.Unavailable;

        public TemporaryData()
        {
            state = State.Available;
        }

        /// <summary>
        /// �ꎞ�f�[�^�����[�h�\���ǂ���
        /// </summary>
        /// <returns></returns>
        public bool CanReceive()
        {
            return state == State.Available;
        }

        /// <summary>
        /// �ꎞ�f�[�^�̏�����
        /// </summary>
        public override void Unload()
        {
            base.Unload();

            state = State.Unavailable;
        }
    }
}
