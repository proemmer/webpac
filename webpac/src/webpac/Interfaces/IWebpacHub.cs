namespace webpac.Interfaces
{
    public interface IWebpacClient
    {
        void DataChanged(string mapping, string variable, object value);
    }
}
