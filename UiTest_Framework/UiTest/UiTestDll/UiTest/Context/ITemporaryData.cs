namespace Assets.UiTest.Context
{
    public interface ITemporaryData
    {
        void Set(string key, object value);
        T Get<T>(string key);
    }
}