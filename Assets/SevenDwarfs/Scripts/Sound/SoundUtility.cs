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
            return SevenDwarfsResource.LoadAndInstantiate<SoundController>("Assets/SevenDwarfs/Prefabs/Sound/SoundController.prefab");
        }
    }
}