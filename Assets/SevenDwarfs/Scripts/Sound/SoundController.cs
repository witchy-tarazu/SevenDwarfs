using UnityEngine;
using UnityEngine.AddressableAssets;

namespace SevenDwarfs.Sound
{
    /// <summary>
    /// サウンド管理MonoBehaviour
    /// SEとBGMを別々に再生・停止できるだけ
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
        /// <summary>ファイル拡張子、ばらけることはあまりないはずなので必要に応じて書き換え</summary>
        private const string SoundSuffix = ".mp3";

        /// <summary>
        /// AudioClipをロードしてきてBGMの再生
        /// 同じBGMだったら継続
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
        /// AudioClipをロードしてきてBGMのSEの再生
        /// 同じSEだったら再度鳴らす
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
        /// パスからクリップをロード
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