using UnityEngine;
using UnityEngine.AddressableAssets;

namespace SevenDwarfs.Sound
{
    /// <summary>
    /// �T�E���h�Ǘ�MonoBehaviour
    /// SE��BGM��ʁX�ɍĐ��E��~�ł��邾��
    /// </summary>
    public class SoundController : MonoBehaviour
    {
        [SerializeField]
        private AudioSource bgmSource;

        [SerializeField]
        private AudioSource seSource;

        private string currentBgmKey = string.Empty;

        private string currentSeKey = string.Empty;

        private const string SoundPrefix = "Assets/SevenDwarfs/Data/Sound/";
        /// <summary>�t�@�C���g���q�A�΂炯�邱�Ƃ͂��܂�Ȃ��͂��Ȃ̂ŕK�v�ɉ����ď�������</summary>
        private const string SoundSuffix = ".mp3";

        /// <summary>
        /// AudioClip�����[�h���Ă���BGM�̍Đ�
        /// ����BGM��������p��
        /// </summary>
        /// <param name="resourceKey"></param>
        public void PlayBgm(string resourceKey)
        {
            if (resourceKey == currentBgmKey)
            {
                return;
            }

            var currentClip = bgmSource.clip;
            Resources.UnloadAsset(currentClip);

            const string BgmPrefix = SoundPrefix + "BGM/";
            AudioClip newClip = LoadAuidpClip(BgmPrefix + resourceKey + SoundSuffix);
            bgmSource.clip = newClip;
            bgmSource.Play();

            currentBgmKey = resourceKey;
        }

        public void StopBgm()
        {
            bgmSource.Stop();
        }

        /// <summary>
        /// AudioClip�����[�h���Ă���BGM��SE�̍Đ�
        /// ����SE��������ēx�炷
        /// </summary>
        /// <param name="resourceKey"></param>
        public void PlaySe(string resourceKey)
        {
            if (resourceKey == currentSeKey)
            {
                seSource.Play();
                return;
            }

            var currentClip = seSource.clip;
            Resources.UnloadAsset(currentClip);

            const string SePrefix = SoundPrefix + "SE/";
            AudioClip newClip = LoadAuidpClip(SePrefix + resourceKey + SoundSuffix);
            seSource.clip = newClip;
            seSource.Play();

            currentSeKey = resourceKey;
        }

        public void StopSe()
        {
            seSource.Stop();
        }

        /// <summary>
        /// �p�X����N���b�v�����[�h
        /// </summary>
        /// <param name="resourceKey"></param>
        /// <returns></returns>
        private AudioClip LoadAuidpClip(string resourceKey)
        {
            var op = Addressables.LoadAssetAsync<AudioClip>(resourceKey);
            var clip = op.WaitForCompletion();
            Addressables.Release(op);

            return clip;
        }
    }
}