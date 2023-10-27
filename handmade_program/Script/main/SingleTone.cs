public class SingleTone<T> where T : class, new()
{
    protected static volatile T _instance;
    public static T instance
    {
        get
        {
            if (_instance is null)
                _instance = new T();
            return _instance;
        }
    }
}