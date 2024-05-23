using Dotnet.Gstreamer.Transcoding.Models;
using Dotnet.Libraries.Base;
using GLib;
using Gst.RtspServer;
using System;

namespace Dotnet.Gstreamer.Transcoding.Services;
/****************************************************************************
   Purpose      :                                                          
   Created By   : GHLee                                                
   Created On   : 5/9/2024 2:00:33 PM                                                    
   Department   : SW Team                                                   
   Company      : Sensorway Co., Ltd.                                       
   Email        : lsirikh@naver.com                                         
****************************************************************************/
internal class TranscodingService : ITranscodingService
{
    #region - Ctors -
    public TranscodingService(ILogService log
                                , TranscodingSetupModel setupModel)
    {
        _log = log;
        _setupModel = setupModel;
    }

    #endregion
    #region - Implementation of Interface -
    public System.Threading.Tasks.Task ExecuteAsync(CancellationToken token = default)
    {
        return System.Threading.Tasks.Task.CompletedTask;
    }

    public System.Threading.Tasks.Task StopAsync(CancellationToken token = default)
    {
        return System.Threading.Tasks.Task.CompletedTask;
    }
    #endregion
    #region - Overrides -
    #endregion
    #region - Binding Methods -
    #endregion
    #region - Processes -
    public void initialize()
    {
        // GStreamer 초기화
        Gst.Application.Init();
        GLib.MainLoop rtspServerLoop = new GLib.MainLoop();

    }

    public void StartServer()
    {
        _server = new RTSPServer
        {
            Service = _setupModel.Port.ToString()
        };
    }

    private RTSPMountPoints? GetMountPoint()
    {
        if(_server != null)
        {
            return _server.MountPoints;
        }
        else
        {
            return null;
        }
    }

    public void AddRtsp(string uri)
    {

        var mounts = GetMountPoint();

        // 미디어 팩토리 생성 및 설정
        var firstFactory = new RTSPMediaFactory
        {
            EnableRtcp = !DisableRtcp,
            Launch = $"rtspsrc location={uri} latency=500 ! rtph264depay ! queue ! h264parse ! identity ! rtph264pay config-interval=1 name=pay0 pt=96",
            Shared = true
        };

        // 마운트 포인트에 팩토리 추가
        mounts.AddFactory($"/{id}/first", firstFactory);

        // 미디어 팩토리 생성 및 설정
        var subFactory = new RTSPMediaFactory
        {
            EnableRtcp = !DisableRtcp,
            Launch = $"rtspsrc location={uri} latency=500 ! rtph264depay ! h264parse ! nvh264dec ! videoconvert ! queue ! videoscale ! videorate !" +
            $" video/x-raw,framerate=15/1,width=1280,height=960 ! x264enc bitrate=1600 speed-preset=ultrafast tune=zerolatency cabac=true ! rtph264pay config-interval=1 name=pay0 pt=96",
            Shared = true
        };

        // 마운트 포인트에 팩토리 추가
        mounts.AddFactory($"/{id}/second", subFactory);

        // 미디어 팩토리 생성 및 설정
        var thirdFactory = new RTSPMediaFactory
        {
            EnableRtcp = !DisableRtcp,
            Launch = $"rtspsrc location={uri} latency=500 ! rtph264depay ! h264parse ! nvh264dec ! videoconvert ! queue ! videoscale ! videorate !" +
            $" video/x-raw,framerate=10/1,width=640,height=480 ! x264enc bitrate=800 speed-preset=ultrafast tune=zerolatency cabac=true ! rtph264pay config-interval=1 name=pay0 pt=96",
            Shared = true
        };

        // 마운트 포인트에 팩토리 추가
        mounts.AddFactory($"/{id}/third", thirdFactory);

        // 미디어 팩토리 생성 및 설정
        var fourthFactory = new RTSPMediaFactory
        {
            EnableRtcp = !DisableRtcp,
            Launch = $"rtspsrc location={uri} latency=500 ! rtph264depay ! h264parse ! nvh264dec ! videoconvert ! queue ! videoscale ! videorate !" +
            $" video/x-raw,framerate=10/1,width=320,height=240 ! x264enc bitrate=400 speed-preset=ultrafast tune=zerolatency cabac=true ! rtph264pay config-interval=1 name=pay0 pt=96",
            Shared = true
        };

        // 마운트 포인트에 팩토리 추가
        mounts.AddFactory($"/{id}/fourth", fourthFactory);
    }

    public void StopServer()
    {

    }
    #endregion
    #region - IHanldes -
    #endregion
    #region - Properties -
    #endregion
    #region - Attributes -
    private ILogService _log;
    private TranscodingSetupModel _setupModel;
    private RTSPServer _server;

    private static readonly bool DisableRtcp = false;
    #endregion
}