using UnityEngine;

namespace SevenDwarfs.MasterData
{
    /// <summary>
    /// �}�X�^�[�f�[�^���R�[�h�pScriptableObject�̊��N���X
    /// </summary>
    public abstract class MasterRecordObjectBase : ScriptableObject
    {
        /// <summary>
        /// ���R�[�h���̂��擾
        /// </summary>
        /// <returns></returns>
        public abstract MasterRecordBase GetRecord();
    }
}