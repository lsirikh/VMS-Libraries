# Sensorway Libraries


### Goal
> VMS 프로젝트에 활용될 라이브러리를 정리하였다. 

### Site : Common
### Branch : main  
### Last Updated : 2024-03-06

### Versions  

* Dotnet.Libraries.Base
* Dotnet.Libraries.Enums
* Dotnet.Libraries.Utils
* Dotnet.OnvifSolution
* Dotnet.OnvifSolution.Base
* Dotnet.OnvifSolution.Collection
* Dotnet.Redis
* DotNet.ResourceMonitor
* Sensorway.Apis
* Sensorway.Apis.MediaMTX
* Sensorway.DB.Solution
* Sensorway.Framework
* Sensorway.Framework.Models
* Sensorway.Framework.ViewBase
* Sensorway.VMS.Messages 


### ver1.3

1. Dotnet.Streaming.UI를 추가하였다.
    - RtspClientSharp의 라이브러리를 활용하여 Rtsp streaming View의 기능을 구현하였다.
    - Ffmpeg 혹은 Vlc 라이브러리를 활용하여 구현한 것으로 안전성과 실시간성에서 우수한 점이 좋다.
    - 추후 CustomControl로 더 변경하면 WPF용으로 손색이 없어 보인다.

2. Dotnet.RtspSharp을 추가하였다.
    - 테스트를 위해 구현하였으나 활용되지 않는다.

3. Dotnet.GstD3DStream.UI를 추가하였다. 
    - VMS의 Clinet 스트리밍 라이브러리로 개발되었고, Gst(Gstreamer sharp)을 활용하여, Direct 3D 11을 wrapping하여 만든 라이브러리이나, 안정성이 떨어지고, C++과 메모리연동에 불안정한점이 해소되지 않아, 적용 보류하게되었다.
    - 성능은 우수하나 안전성과 실시간성이 다소 떨어지는 단점 등이 있다.

4. D3d Source, C_Source는 C++라이브러리들을 모아놓은 폴더 구조이다.


