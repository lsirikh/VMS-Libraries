# Sensorway Libraries

### Goal
> VMS 프로젝트에 활용될 라이브러리를 정리하였다. 

### Site : Common
### Branch : main  

### Libraries  

* C_Source
* D3d Source
* Dotnet.GstD3DStream.UI
* Dotnet.Gstreamer.Transcoding
* Dotnet.Libraries.Base
* Dotnet.Libraries.Enums
* Dotnet.Libraries.LibVlcRtsp.UI
* Dotnet.Libraries.Utils
* Dotnet.OnvifSolution
* Dotnet.OnvifSolution.Base
* Dotnet.OnvifSolution.Collection
* Dotnet.Redis
* DotNet.ResourceMonitor
* Dotnet.RtspSharp
* Dotnet.Streaming.UI
* Gst-Sharp
* Sensoryway.Accounts.Base
* Sensoryway.Accounts.Collection
* Sensoryway.Api.Server
* Sensoryway.Apis
* Sensoryway.Apis.MediaMTX
* Sensoryway.Apis.TranscodingServer
* Sensoryway.DB.Solution
* Sensoryway.Events.Base
* Sensoryway.Events.Collection
* Sensoryway.Framework
* Sensoryway.Framework.Models
* Sensoryway.Framework.ViewBase
* Sensoryway.VMS.Messages


### v1.3

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


### v1.4

1. LogService의 기능을 변경하여, 로그 정보 시현 창에 줄 수 있는 이벤트를 구현.  
2. Dotnet.OnvifSolution 일부 기능 추가/변경하여 예외 발생하는 상황을 최대한 완화 하기 위해서 조치하였다.  
3. Dotnet.GstD3DStream.UI의 폐기 하였다. 추후 D3D 관련 라이브러리는 모두 제거될 예정이다.
4. SimpleRTSP nuget 라이브러리를 기반으로 Streaming라이브러리를 구축하여 클라이언트 사이드에 적용하였다.  
5. Sensorway.DB.Solution 에 Account 부분과 Event 부분이 추가 되었다.  
6. Sensorway.Apis.TranscodingServer가 추가되어 TranscodingServer의 제어가 가능하게 되었다.  
7. Sensorway.Api.Server가 추가되어 PIDS monitoring system과 연동이 가능해졌다.  
8. Sensorway.Apis 를 업데이트 하여, 멀티 베이스라이브러리 시스템을 구축하였다. 즉 한개의 Base 라이브러리(Sensorway.Apis)가 다양한 API 서버에 베이스 라이브러리로 활용되어도 간섭과 중복 없이 적용할 수 있게 되었다.  
9. Dotnet.ResourceMonitor가 업데이트 되어서 로그 창에서 다양한 이벤트 내역을 확인 할 수 있다. 또한, 각종 컴퓨터 자원의 상태를 실시간으로 확인이 가능해졌다.  
10. 그 외 VMS Message와 관련된 사항들이 업데이트 되었다.   
    첫 째, Account 부문의 업데이트    
    둘 째, Event 부문의 업데이트  
    셋 째, 그 외의 시스템적인 부분의 업데이트(예 트랜스 코딩 서버 파트와 통신 등)  
11. Dotnet.Streaming.UI이 추가되었고, 클라이이언트의 메인 스트리밍 라이브러리로 적용되었다.  


### v1.4.1
### Date 2025-01-06

1. ResoruceMonitorService 기능의 Task.Run의 무리한 활용을 줄이고, Async 타입으로 개선하는 작업을 하였고, 일부 서비스 안되는 기능은 안정성을 강화 하였다.  
2. StreamingViewModel의 기능을 수정하고 AccessViolation 에러를 안정화 시켰다.(FFmpegVideoDecoder.cs)  
3. Sensroway.Accounts.Base의 UserBaseModel의 클래스를 BaseModel을 상속받도록 수정하였다.  
4. ILogService를 Sensorway.Framework.Viewbase에 적용을 하였다.  
