using UnityEngine;
namespace SevenDwarfs.Kamishibai
{
    public static class KamishibaiUtility
    {
        /// <summary>
        /// Kamishibai��prefab�Ƃ��ă��[�h����
        /// EventSystem���Ȃ��Ɠ����Ȃ��̂Œ���
        /// </summary>
        /// <returns></returns>
        public static KamishibaiController LoadKamishibai(Transform parent)
        {
            var kamishibai = SevenDwarfsResource.LoadAndInstantiate<KamishibaiController>(parent, "Assets/SevenDwarfs/Prefabs/Kamishibai/KamishibaiCanvas.prefab");
            kamishibai.Hide();
            return kamishibai;
        }
    }
}