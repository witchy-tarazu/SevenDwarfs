using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using System;
using UnityEditor;

namespace SevenDwarfs.MasterData
{
    public class MasterDataCompressor
    {
        /// <summary>
        /// �}�X�^�[�f�[�^���k
        /// </summary>
        [MenuItem("SevenDwarfs/Compress MasterData")]
        private static void CompressMasterData()
        {
            // Example:
            // CreateMasterDataObject<MasterHoge, MasterHogeRecordObject>();
        }

        /// <summary>
        /// �C�ӂ̃}�X�^�[�f�[�^�̈��k����
        /// </summary>
        /// <typeparam name="MasterDataType"></typeparam>
        /// <typeparam name="MasterRecordObjectType"></typeparam>
        private static void CreateMasterDataObject<MasterDataType, MasterRecordObjectType>()
            where MasterDataType : MasterDataBase
            where MasterRecordObjectType : MasterRecordObjectBase
        {
            var dataList = AccumulateMasterData<MasterRecordObjectType>();

            if (dataList.Count == 0)
            {
                return;
            }

            MasterDataType newMasterData = ScriptableObject.CreateInstance<MasterDataType>();
            newMasterData.SetDataList(dataList);


            var type = typeof(MasterDataType);
            var typeName = type.Name;
            var path = string.Format("Assets/SevenDwarfs/Data/MasterData/" + typeName + ".asset");
            var oldMasterData = AssetDatabase.LoadAssetAtPath<MasterDataType>(path);
            if (oldMasterData != null)
            {
                // ���݂���Ȃ��U�폜
                // EditorUtility.CopySerialized�ŏ㏑������mName��������̂Ŏb��Ή�
                AssetDatabase.DeleteAsset(path);
            }

            AssetDatabase.CreateAsset(newMasterData, path);
            AssetDatabase.Refresh();

            Debug.Log(string.Format("�}�X�^�[�f�[�^{0}�̏o�͂��������܂����B", typeName));
        }

        /// <summary>
        /// �C�ӂ̃}�X�^�[�f�[�^���R�[�h�����W
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        private static List<MasterRecordBase> AccumulateMasterData<T>() where T : MasterRecordObjectBase
        {
            var type = typeof(T);
            var typeName = type.Name;
            var recordTypeName = type.GetField("record").FieldType.Name;
            var guidArray = AssetDatabase.FindAssets("t:" + typeName, new[] { "Assets/SevenDwarfs/Editor/MasterData/Data/" + recordTypeName });

            List<MasterRecordBase> dataList = new();
            foreach (var guid in guidArray)
            {
                var assetPath = AssetDatabase.GUIDToAssetPath(guid);
                var scriptableObject = AssetDatabase.LoadAssetAtPath<T>(assetPath);
                dataList.Add(scriptableObject.GetRecord());
            }

            if (dataList.Count == 0)
            {
                Debug.Log(string.Format("{0}�N���X�̃��R�[�h�͌�����܂���ł����B", typeName));
            }

            return dataList;
        }
    }
}
