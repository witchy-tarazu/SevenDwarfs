using UnityEngine;
using UnityEngine.AddressableAssets;

namespace SevenDwarfs.Sound
{
    public static class SoundUtility
    {
        /// <summary>
        /// SoundController��prefab�Ƃ��ă��[�h����
        /// �d���`�F�b�N�����Ȃ��̂ƁAAudioListener��MainCamera�����肪�����Ă���z��ɂȂ��Ă���̂Œ���
        /// </summary>
        /// <returns></returns>
        public static SoundController LoadSoundController()
        {
            var op = Addressables.LoadAssetAsync<GameObject>("Assets/SevenDwarfs/Prefabs/Sound/SoundController.prefab");
            var prefab = op.WaitForCompletion();
            Addressables.Release(op);

            var controller = UnityEngine.Object.Instantiate(prefab);
            return controller.GetComponent<SoundController>();
        }
    }
}