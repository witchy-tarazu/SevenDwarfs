using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SevenDwarfs.MasterData
{
    public class MasterDataManager
    {
        private Dictionary<Type, MasterDataBase> masterDataCache;

        public MasterDataManager()
        {
            masterDataCache = new();
        }

        /// <summary>
        /// マスターデータ取得
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T GetMaster<T>() where T : MasterDataBase
        {
            var masterType = typeof(T);
            if (masterDataCache.TryGetValue(masterType, out MasterDataBase masterData))
            {
                return masterData as T;
            }
            else
            {
                var fileName = masterType.Name;
                string resourceName = string.Format("Assets/SevenDwarfs/Data/MasterData/{0}.asset", fileName);
                var loadedMaster = SevenDwarfsResource.Load<T>(resourceName);
                masterDataCache.Add(masterType, loadedMaster);
                return loadedMaster;
            }
        }
    }
}