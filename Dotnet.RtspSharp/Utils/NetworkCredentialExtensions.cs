using System.Net;

namespace Dotnet.RtspSharp.Utils
{
    static class NetworkCredentialExtensions
    {
        public static bool IsEmpty(this NetworkCredential networkCredential)
        {
            if (string.IsNullOrEmpty(networkCredential.UserName) || networkCredential.Password == null)
                return true;

            return false;
        }
    }
}