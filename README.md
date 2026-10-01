# VMS Libraries

VMS 개발에 사용하는 영상 재생·변환, ONVIF 카메라 제어, 메시지와 API 연동 라이브러리 모음입니다. WPF 영상 화면과 네이티브 영상 처리 모듈을 함께 다룹니다.

## 주요 구성

| 경로 | 내용 |
|---|---|
| [Dotnet.Libraries.LibVlcRtsp.UI](Dotnet.Libraries.LibVlcRtsp.UI) | LibVLC 기반 RTSP UI |
| [Dotnet.Streaming.UI](Dotnet.Streaming.UI) | 영상 수신·디코딩·화면 처리 |
| [Dotnet.Gstreamer.Transcoding](Dotnet.Gstreamer.Transcoding) | GStreamer 연동 |
| [Dotnet.OnvifSolution](Dotnet.OnvifSolution) | ONVIF 기능 |
| [Sensorway.Apis.MediaMTX](Sensorway.Apis.MediaMTX) | MediaMTX API 연동 |
| [Sensorway.Apis.TranscodingServer](Sensorway.Apis.TranscodingServer) | 변환 서버 API 연동 |
| [DotNet.ResourceMonitor](DotNet.ResourceMonitor) | 시스템 자원 모니터링 |

## 개발 환경과 범위

주요 프로젝트는 .NET Framework 4.8이며 `Dotnet.Gstreamer.Transcoding`은 .NET 7 Windows를 대상으로 합니다. Windows 개발 도구, 각 프로젝트의 NuGet 패키지, LibVLC·GStreamer·FFmpeg 등 사용하는 모듈의 네이티브 의존성을 준비해야 합니다.

프로젝트마다 대상 프레임워크와 참조 경로가 달라 단일 명령으로 전체가 빌드된다고 가정할 수 없습니다. 특히 서로 다른 프레임워크 간 프로젝트 참조는 빌드 전에 정리가 필요합니다.

완성된 NVR 제품 전체가 아닌 관련 라이브러리 저장소입니다. 포함된 Sensorway 코드와 외부 라이브러리의 출처 표기를 유지합니다.
