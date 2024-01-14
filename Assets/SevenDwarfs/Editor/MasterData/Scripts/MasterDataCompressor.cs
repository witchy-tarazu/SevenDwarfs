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
        /// マスターデータ圧縮
        /// </summary>
        [MenuItem("SevenDwarfs/Compress MasterData")]
        private static void CompressMasterData()
        {
            // Example:
            // CreateMasterDataObject<MasterHoge, MasterHogeRecordObject>();
        }

        /// <summary>
        /// 任意のマスターデータの圧縮処理
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
                // 存在するなら一旦削除
                // EditorUtility.CopySerializedで上書きだとmNameが消えるので暫定対応
                AssetDatabase.DeleteAsset(path);
            }

            AssetDatabase.CreateAsset(newMasterData, path);
            AssetDatabase.Refresh();

            Debug.Log(string.Format("マスターデータ{0}の出力が完了しました。", typeName));
        }

        /// <summary>
        /// 任意のマスターデータレコードを収集
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
                Debug.Log(string.Format("{0}クラスのレコードは見つかりませんでした。", typeName));
            }

            return dataList;
        }
    }
}
