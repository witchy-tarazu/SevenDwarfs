namespace SevenDwarfs.CrossingData
{
    public abstract class CrossingDataBase
    {
        /// <summary>
        /// ƒf[ƒ^‚Ì‰Šú‰»
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
