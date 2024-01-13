using System;
using System.Collections.Generic;

namespace SevenDwarfs.CrossingData
{
    /// <summary>
    /// �󂯓n���̂��߂Ɉꎞ�I�Ɏg�p����f�[�^�̊Ǘ��N���X
    /// �g���؂�Ȃ̂Ńf�[�^����ꂽ��Ƀ��[�h����ƃf�[�^��������̂͒���
    /// </summary>
    public sealed class TemporaryDataManager
    {
        public Dictionary<Type, TemporaryData> dataDictionary;

        public TemporaryDataManager()
        {
            dataDictionary = new();
        }

        /// <summary>
        /// ������
        /// �\�t�g�E�F�A���Z�b�g�|����Ƃ��͌Ă�
        /// </summary>
        public void Reset()
        {
            dataDictionary.Clear();
        }

        /// <summary>
        /// �ꎞ�f�[�^�̕ۊ�
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="temporaryData"></param>
        public void Register<T>(T temporaryData) where T : TemporaryData
        {
            dataDictionary[typeof(T)] = temporaryData;
        }

        /// <summary>
        /// �ꎞ�f�[�^�̎󂯎�菈�������s
        /// �g���؂�
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
