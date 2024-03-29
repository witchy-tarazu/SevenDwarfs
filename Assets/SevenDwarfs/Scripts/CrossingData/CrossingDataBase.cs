namespace SevenDwarfs.CrossingData
{
    public abstract class CrossingDataBase
    {
        /// <summary>
        /// データの初期化
        /// </summary>
        public virtual void Unload()
        {
            var fields = GetType().GetFields();
            foreach (var field in fields)
            {
                var n = field.Name;
                field.SetValue(n, default);
            }
        }
    }
}
