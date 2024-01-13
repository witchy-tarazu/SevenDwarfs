using UnityEditor;
using UnityEngine;
using System.IO;
using System.Linq;


namespace SevenDwarfs.MasterData
{
    /// <summary>
    /// データ出力用ScriptableObjectのテンプレート
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
        /// データリストを設定
        /// </summary>
        public override void SetDataList(List<MasterRecordBase> dataList)
        {{
            this.dataList = dataList.Cast<{0}> ().ToList();
        }}

        /// <summary>
        /// 条件に合致するレコードを取得
        /// 複数あれば一番上
        /// </summary>
        public {0} Search(Func<{0}, bool> evaluationFomula)
        {{
            return dataList.Where(evaluationFomula).FirstOrDefault();
        }}

        /// <summary>
        ///  条件に合致するレコード一覧を取得
        /// </summary>
        public List<{0}> SearchList(Func<{0},bool> evaluationFomula)
        {{
        return dataList.Where(evaluationFomula).ToList();
        }}
    }}
}}
";

        /// <summary>
        /// データ入力用ScriptableObjectのテンプレート
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
        /// データリストを設定
        /// </summary>
        public override MasterRecordBase GetRecord()
        {{
            return record;
        }}
    }}
}}
";

        /// <summary>
        /// マスターデータクラスの出力
        /// </summary>
        [MenuItem("SevenDwarfs/Generate MasterData Scrips")]
        public static void GenerateMasterDataScripts()
        {
            DirectoryInfo directoryInfo = new("Assets/SevenDwarfs/Scripts/MasterData/RecordClasses");
            var classNames = directoryInfo.GetFiles("*.cs")
                .Select(fileInfo => fileInfo.Name.Split(".")[0]);

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
            }

            AssetDatabase.Refresh();
        }
    }
}