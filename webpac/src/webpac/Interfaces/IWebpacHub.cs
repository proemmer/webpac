namespace webpac.Interfaces
{
    /// <summary>
    /// Hub client interface
    /// </summary>
    public interface IWebpacClient
    {
        /// <summary>
        /// This method will be called on the client when data of an active variable change
        /// </summary>
        /// <param name="mapping">name of the mapping</param>
        /// <param name="variable">name of the variable</param>
        /// <param name="value">new data</param>
        void DataChanged(string mapping, string variable, object value, bool isRaw);

        /// <summary>
        /// This method will be called when the plc connection was be changed
        /// </summary>
        /// <param name="connected"></param>
        void ConnectionChanged(bool connected);
    }
}
