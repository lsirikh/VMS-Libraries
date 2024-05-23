using System;

namespace Dotnet.Gstreamer.Transcoding.Models;
/****************************************************************************
   Purpose      :                                                          
   Created By   : GHLee                                                
   Created On   : 5/9/2024 2:18:19 PM                                                    
   Department   : SW Team                                                   
   Company      : Sensorway Co., Ltd.                                       
   Email        : lsirikh@naver.com                                         
****************************************************************************/
public class TranscodingSetupModel
{
    #region - Ctors -
    #endregion
    #region - Implementation of Interface -
    #endregion
    #region - Overrides -
    #endregion
    #region - Binding Methods -
    #endregion
    #region - Processes -
    #endregion
    #region - IHanldes -
    #endregion
    #region - Properties -
    public int Port { get; set; }
    public string OptionFirst { get; set; } = "latency=500 ! rtph264depay ! queue ! h264parse ! identity ! rtph264pay config-interval=1 name=pay0 pt=96";
    public string OptionSecond { get; set; } = "latency=500 ! rtph264depay ! h264parse ! nvh264dec ! videoconvert ! queue ! videoscale ! videorate ! video/x-raw,framerate=20/1,width=1280,height=960 ! x264enc bitrate=1600 speed-preset=ultrafast tune=zerolatency cabac=true ! rtph264pay config-interval=1 name=pay0 pt=96";
    public string OptionThird { get; set; } = "latency=500 ! rtph264depay ! h264parse ! nvh264dec ! videoconvert ! queue ! videoscale ! videorate ! video/x-raw,framerate=15/1,width=640,height=480 ! x264enc bitrate=800 speed-preset=ultrafast tune=zerolatency cabac=true ! rtph264pay config-interval=1 name=pay0 pt=96";
    public string OptionFourth { get; set; } = "latency=500 ! rtph264depay ! h264parse ! nvh264dec ! videoconvert ! queue ! videoscale ! videorate ! video/x-raw,framerate=10/1,width=320,height=240 ! x264enc bitrate=400 speed-preset=ultrafast tune=zerolatency cabac=true ! rtph264pay config-interval=1 name=pay0 pt=96";
    #endregion
    #region - Attributes -
    #endregion
}