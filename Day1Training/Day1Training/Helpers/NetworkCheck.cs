using Plugin.Connectivity;

namespace Day1Training.Helpers
{
    /// <summary>
    /// class th check the network connectivity 
    /// </summary>
    public class NetworkCheck
    {
        /// <summary>
        /// method to check the network status using CrossConnectivity plugin 
        /// </summary>
        /// <returns></returns>
        public static bool IsInternet()
        {
            if (CrossConnectivity.Current.IsConnected(0))
            {
                return true;
            }
            else
            {   
                return false;
            }
        }
    }
}
