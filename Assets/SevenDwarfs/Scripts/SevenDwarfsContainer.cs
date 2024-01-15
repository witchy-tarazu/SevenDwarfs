using SevenDwarfs.CrossingData;
using SevenDwarfs.Kamishibai;
using SevenDwarfs.MasterData;
using SevenDwarfs.Popup;
using SevenDwarfs.SaveData;
using SevenDwarfs.Sound;
using UnityEngine;
using UnityEngine.EventSystems;

namespace SevenDwarfs
{
    public class SevenDwarfsContainer
    {
        public CrossingDataManager CrossingDataManager { get; private set; }
        public KamishibaiController KamishibaiController { get; private set; }
        public MasterDataManager MasterDataManager { get; private set; }
        public PopupController PopupController { get; private set; }
        public SaveDataManager SaveDataManager { get; private set; }
        public SoundController SoundController { get; private set; }

        /// <summary>
        /// �R���X�g���N�^
        /// ����ɃI�u�W�F�N�g�����̂Œ���
        /// </summary>
        /// <param name="parent"></param>
        public SevenDwarfsContainer(Transform parent)
        {
            CrossingDataManager = new();
            MasterDataManager = new();
            SaveDataManager = new();

            KamishibaiController = KamishibaiUtility.LoadKamishibai(parent);
            PopupController = PopupUtility.LoadPopupController(parent);
            SoundController = SoundUtility.LoadSoundController(parent);

            // EventSystem���Ȃ������珟��ɍ��
            if (EventSystem.current == null)
            {
                var eventSystem = new GameObject("EventSystem", typeof(EventSystem), typeof(StandaloneInputModule));
                eventSystem.transform.parent = parent;
            }
        }
    }
}