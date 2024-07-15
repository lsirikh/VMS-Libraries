using System;

namespace Sensorway.Apis.TranscodingServer.Models
{
    public interface IMediaModel
    {
        string Id { get; set; }
        string Username { get; set; }
        string Password { get; set; }
        string Ip { get; set; }
        string Port { get; set; }
        string Path { get; set; }
        string FullPath { get; set; }
        DateTime? ReadyTime { get; set; }
        MountPointsModel MountPoints { get; set; }
    }
}