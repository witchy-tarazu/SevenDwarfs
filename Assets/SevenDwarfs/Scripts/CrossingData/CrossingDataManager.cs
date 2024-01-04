using System;

namespace SevenDwarfs.CrossingData
{
    public sealed class CrossingDataManager : SevenDwarfsSingleton<CrossingDataManager>
    {
        private PermanentDataManager permanentDataManager;
        private TemporaryDataManager temporaryDataManager;

        public CrossingDataManager()
        {
            permanentDataManager = new();
            temporaryDataManager = new();
        }

        public void ResetData()
        {
            permanentDataManager.Reset();
            temporaryDataManager.Reset();
        }

        /// <summary>
        /// �P�v�f�[�^�̓o�^
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="permanentData"></param>
        public void RegisterPermanent<T>(T permanentData) where T : PermanentData
        {
            permanentDataManager.Register(permanentData);
        }

        /// <summary>
        /// �P�v�f�[�^�̎擾
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T LoadPermanent<T>() where T : PermanentData
        {
            return permanentDataManager.Load<T>();
        }

        /// <summary>
        /// �ꎞ�f�[�^�̓o�^
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="temporaryData"></param>
        public void RegisterTemporary<T>(T temporaryData) where T : TemporaryData
        {
            temporaryDataManager.Register(temporaryData);
        }


        /// <summary>
        /// �ꎞ�f�[�^����̔��f�������s
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="action"></param>
        /// <returns></returns>
        public bool TryReceiveTemporary<T>(Action<T> action) where T : TemporaryData
        {
            return temporaryDataManager.TryToReceive(action);
        }
    }
}