namespace SevenDwarfs
{
    /// <summary>
    /// �V���O���g��
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SevenDwarfsSingleton<T> where T : class, new()
    {
        private static T instance;

        public static T Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new T();
                }

                return instance;
            }
        }
    }
}
