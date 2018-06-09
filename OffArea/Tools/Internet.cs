
using Android.App;
using Android.Content;
using Android.Net;

namespace OffArea.Tools
{
    public class Internet
    {
        public Internet()
        {

        }
        public static bool CheckNetworkConnection()
        {
            var connectivityManager = (ConnectivityManager)Application.
                                       Context.GetSystemService(Context.ConnectivityService);
            var activeNetworkInfo = connectivityManager.ActiveNetworkInfo;
            if (activeNetworkInfo != null && activeNetworkInfo.IsConnectedOrConnecting)
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