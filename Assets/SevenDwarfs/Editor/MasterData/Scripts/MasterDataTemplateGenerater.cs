using UnityEditor;
using UnityEngine;
using System.IO;
using System.Linq;


namespace SevenDwarfs.MasterData
{
    /// <summary>
    /// �f�[�^�o�͗pScriptableObject�̃e���v���[�g
    /// </summary>
    public class MasterDataTemplateGenerater
    {
        private const string MasterDataTemplate = @"/// AUTO GENERATED ///
using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

namespace SevenDwarfs.MasterData
{{
    public class Master{0} : MasterDataBase
    {{
        [SerializeField]
        private List<{0}> dataList;

        /// <summary>
        /// �f�[�^���X�g��ݒ�
        /// </summary>
        public override void SetDataList(List<MasterRecordBase> dataList)
        {{
            this.dataList = dataList.Cast<{0}> ().ToList();
        }}

        /// <summary>
        /// �����ɍ��v���郌�R�[�h���擾
        /// ��������Έ�ԏ�
        /// </summary>
        public {0} Search(Func<{0}, bool> evaluationFomula)
        {{
            return dataList.Where(evaluationFomula).FirstOrDefault();
        }}

        /// <summary>
        ///  �����ɍ��v���郌�R�[�h�ꗗ���擾
        /// </summary>
        public List<{0}> SearchList(Func<{0},bool> evaluationFomula)
        {{
        return dataList.Where(evaluationFomula).ToList();
        }}
    }}
}}
";

        /// <summary>
        /// �f�[�^���͗pScriptableObject�̃e���v���[�g
        /// </summary>
        private const string MasterRecordObjectTemplate = @"/// AUTO GENERATED ///
using UnityEngine;

namespace SevenDwarfs.MasterData
{{
    [CreateAssetMenu(menuName = ""SevenDwarfs/MasterData/{0}"")]
    public class Master{0}RecordObject : MasterRecordObjectBase
    {{
        public {0} record;

        /// <summary>
        /// �f�[�^���X�g��ݒ�
        /// </summary>
        public override MasterRecordBase GetRecord()
        {{
            return record;
        }}
    }}
}}
";
        private const string CompressorTemplete = @"/// AUTO GENERATED ///
using UnityEditor;

namespace SevenDwarfs.MasterData
{{
    public static partial class MasterDataCompressor
    {{
        /// <summary>
        /// �}�X�^�[�f�[�^���k
        /// </summary>
        [MenuItem(""SevenDwarfs/Compress MasterData"")]
        private static void CompressMasterData()
        {{
{0}
        }}
    }}
}}
";

        /// <summary>
        /// Compressor�ł̃t�@�C����`
        /// </summary>
        private const string CompressorEachClassTemplate = "            CreateMasterDataObject<Master{0}, Master{0}RecordObject>();";


        /// <summary>
        /// �}�X�^�[�f�[�^�N���X�̏o��
        /// </summary>
        [MenuItem("SevenDwarfs/Generate MasterData Scripts")]
        public static void GenerateMasterDataScripts()
        {
            DirectoryInfo directoryInfo = new("Assets/SevenDwarfs/Scripts/MasterData/RecordClasses");
            var classNames = directoryInfo.GetFiles("*.cs")
                .Select(fileInfo => fileInfo.Name.Split(".")[0]);

            string createText = string.Empty;
            foreach (var className in classNames)
            {
                var generatedDirectoryPath = "Assets/SevenDwarfs/Scripts/MasterData/Generated";
                if (!Directory.Exists(generatedDirectoryPath))
                {
                    Directory.CreateDirectory(generatedDirectoryPath);
                }

                var masterPath = string.Format("Assets/SevenDwarfs/Scripts/MasterData/Generated/Master" + className + ".cs");
                var oldMaster = AssetDatabase.LoadAssetAtPath<Object>(masterPath);
                if (oldMaster != null)
                {
                    AssetDatabase.DeleteAsset(masterPath);
                }
                File.WriteAllText(masterPath, string.Format(MasterDataTemplate, className));

                var recordObjectPath = string.Format("Assets/SevenDwarfs/Scripts/MasterData/Generated/Master" + className + "RecordObject.cs");
                var oldRecordObject = AssetDatabase.LoadAssetAtPath<Object>(recordObjectPath);
                if (oldRecordObject != null)
                {
                    AssetDatabase.DeleteAsset(recordObjectPath);
                }
                File.WriteAllText(recordObjectPath, string.Format(MasterRecordObjectTemplate, className));

                var dataDirectoryPath = "Assets/SevenDwarfs/Editor/MasterData/Data/" + className;
                if (!Directory.Exists(dataDirectoryPath))
                {
                    Directory.CreateDirectory(dataDirectoryPath);
                }

                createText += string.Format(CompressorEachClassTemplate, className);
            }

            var compressorPath = string.Format("Assets/SevenDwarfs/Editor/MasterData/Scripts/Generated/GeneratedMasterDataCompressor.cs");
            var oldFile = AssetDatabase.LoadAssetAtPath<Object>(compressorPath);
            if (oldFile != null)
            {
                AssetDatabase.DeleteAsset(compressorPath);
            }
            File.WriteAllText(compressorPath, string.Format(CompressorTemplete, createText));

            AssetDatabase.Refresh();
        }
    }
}