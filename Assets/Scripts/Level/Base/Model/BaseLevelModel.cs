namespace Level.Model
{
    public abstract class BaseLevelModel<T> where T:BaseLevelModel<T>,new()
    {
        protected static BaseLevelModel<T> _instance;

        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new T();
                }
                return (_instance as T);
            }
        }
    }
}