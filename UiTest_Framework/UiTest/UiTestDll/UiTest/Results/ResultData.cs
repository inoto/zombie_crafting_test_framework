namespace Assets.UiTest.Results
{
    public class ResultData<T> where T: ICommandResult
    {
        private T _result;

        public void SetData(T result)
        {
            _result = result;
        }
        public T GetData()
        {
            return _result;
        }
        
    }
}