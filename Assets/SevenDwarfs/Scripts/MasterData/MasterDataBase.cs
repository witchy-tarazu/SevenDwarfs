using System.Collections.Generic;
using UnityEngine;

namespace SevenDwarfs.MasterData
{
    /// <summary>
    /// ���k�}�X�^�[�f�[�^�pScriptableObject�̊��N���X
    /// MasterDataRecordBase�̃T�u�N���X��List���t�B�[���h�Ɏ�������
    /// </summary>
    public abstract class MasterDataBase : ScriptableObject
    {
        /// <summary>
        /// �f�[�^���X�g��ݒ�
        /// </summary>
        public abstract void SetDataList(List<MasterRecordBase> dataList);
    }
}