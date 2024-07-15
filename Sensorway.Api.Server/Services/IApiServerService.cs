using Sensorway.Api.Server.Enums;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Sensorway.Api.Server.Services
{
    public interface IApiServerService
    {

        void ServerActivate();
        void ServerDeactivate();
        Task ServerStart(CancellationToken token);
        Task SendResponse(HttpListenerResponse response = default, string json = default, bool isSuccess = true);
        EnumApiServerStatus Status { get; }
        HttpListener HttpListener { get; }

        event EventHandler ReceiveEvent;
        event Action StatusChanged;
    }
}