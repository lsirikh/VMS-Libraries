using Dotnet.Libraries.Base;
using Dotnet.Redis.Models;
using System;
using System.Threading.Tasks;

namespace Dotnet.Redis.Services
{
    public interface IMessageService<T> : IService
    {
        T Connect(RedisSetupModel setupModel);
        Task<T> ConnectAsync(RedisSetupModel setupModel);
        Task PublishAsync(string channel, string msg);
        //event EventHandler<ChannelMessage> ChannelEventHandler;
        //event EventHandler<ChannelMessage> RedisSubscribeEvent;

        //동기식 수신 이벤트 핸들러
        event EventHandler<MessageArgsModel> RedisSubscribeEvent;
        //비동기식 수신 이벤트 핸들러
        event Func<MessageArgsModel, Task> RedisSubscribeEventAsync;

    }
}