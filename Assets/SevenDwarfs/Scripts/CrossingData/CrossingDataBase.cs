namespace SevenDwarfs.CrossingData
{
    public abstract class CrossingDataBase
    {
        /// <summary>
        /// �f�[�^�̏�����
        /// </summary>
        public virtual void Unload()
        {
            var types = GetType().GetFields();
            foreach (var type in types)
            {
                var n = type.Name;
                type.SetValue(n, default);
            }
        }
    }
}
