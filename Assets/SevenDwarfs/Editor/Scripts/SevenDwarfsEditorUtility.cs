using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEditor;

namespace SevenDwarfs
{
    public static class SevenDwarfsEditorUtility
    {
        /// <summary>
        /// 空ディレクトリを一括で作成する
        /// </summary>
        [MenuItem("SevenDwarfs/Prepare Empty Directories")]
        public static void PrepareEmptyDirectories()
        {
            CreateDirectory("Assets/SevenDwarfs/Data");
            CreateDirectory("Assets/SevenDwarfs/Data/Kamishibai");
            CreateDirectory("Assets/SevenDwarfs/Data/Kamishibai/Character");
            CreateDirectory("Assets/SevenDwarfs/Data/Kamishibai/Scenario");
            CreateDirectory("Assets/SevenDwarfs/Data/MasterData");
            CreateDirectory("Assets/SevenDwarfs/Data/Popup");
            CreateDirectory("Assets/SevenDwarfs/Data/Sound");
            CreateDirectory("Assets/SevenDwarfs/Data/Sound/BGM");
            CreateDirectory("Assets/SevenDwarfs/Data/Sound/SE");

            CreateDirectory("Assets/SevenDwarfs/Editor/MasterData/Data");

            CreateDirectory("Assets/SevenDwarfs/Scripts/MasterData/RecordClasses");

            AssetDatabase.Refresh();
        }

        /// <summary>
        /// 存在チェックして作成
        /// </summary>
        /// <param name="path"></param>
        private static void CreateDirectory(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }
    }
}