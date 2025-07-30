using Dotnet.Libraries.Base;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Sensorway.Apis.Services
{
    public interface IApiService : IService
    {
        Task<HttpResponseMessage> GetRequest(string url, bool isAuthentication = false, FormUrlEncodedContent formContent = null);
        Task<HttpResponseMessage> GetRequest(string url, Dictionary<string, string> customHeaders, bool isAuthentication = false);
        Task<HttpResponseMessage> PostRequest(string body, string url, bool isAuthentication = false);
        Task<HttpResponseMessage> PostRequest(string body, string url, Dictionary<string, string> customHeaders, bool isAuthentication = false);
        Task<HttpResponseMessage> DeleteRequest(string url, bool isAuthentication = false);
        Task<HttpResponseMessage> DeleteRequest(string url, Dictionary<string, string> customHeaders, bool isAuthentication = false);
        Task<HttpResponseMessage> PatchRequest(string url, string content, bool isAuthentication = false);
        Task<HttpResponseMessage> PutRequest(string url, string json, bool isAuthentication = false);
    }
}