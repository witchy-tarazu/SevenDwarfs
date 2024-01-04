using System;
using System.Collections.Generic;

namespace SevenDwarfs.CrossingData
{
    /// <summary>
    /// �N�����̍P�v�f�[�^�̊Ǘ��N���X
    /// ������̓C���X�^���X�����̂܂ܕԂ�
    /// </summary>
    public sealed class PermanentDataManager
    {
        public Dictionary<Type, PermanentData> dataDictionary;

        public PermanentDataManager()
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
        /// <param name="permanentData"></param>
        public void Register<T>(T permanentData) where T : PermanentData
        {
            dataDictionary[typeof(T)] = permanentData;
        }

        /// <summary>
        /// ���[�h���������s
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
