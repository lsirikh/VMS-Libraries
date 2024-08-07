﻿using Caliburn.Micro;
using LibVLCSharp.Shared;
using System.Threading.Tasks;
using System.Threading;
using System.Reflection;
using System;
using System.IO;
using System.Diagnostics;
using Dotnet.Libraries.LibVlcRtsp.UI.Modules;

namespace Dotnet.Libraries.LibVlcRtsp.UI.ViewModels
{
    /****************************************************************************
        Purpose      :                                                           
        Created By   : GHLee                                                
        Created On   : 8/30/2023 6:01:40 PM                                                    
        Department   : SW Team                                                   
        Company      : Sensorway Co., Ltd.                                       
        Email        : lsirikh@naver.com                                         
     ****************************************************************************/

    public class VlcComponentViewModel : Screen
    {

        #region - Ctors -
        public VlcComponentViewModel(VlcMediaPlayer vlcMediaPlayer)
        {
            #region Deprecated
            //Core.Initialize();
            ////_libVLC = new LibVLC("--verbose=2");
            //_libVLC = new LibVLC();
            ////var options = new string[]
            ////            {
            ////                "--network-caching=250"
            ////                ,"--sout-qsv-software"
            ////                , "--sout-mux-caching=300"
            ////                //, "--network-synchronisation"
            ////                , "--directx-use-sysmem"
            ////                //, $"{VlcControl.ActualWidth}x{VlcControl.ActualHeight}"
            ////            };
            //_mediaPlayer = new MediaPlayer(_libVLC);
            //_mediaPlayer.NetworkCaching = 100;
            //_mediaPlayer.FileCaching = 300;
            #endregion

            //_mediaPlayer = IoC.Get<VlcMediaPlayer>();
            _mediaPlayer = vlcMediaPlayer;
            _mediaPlayer.NetworkCaching = 200;
            _mediaPlayer.FileCaching = 300;
        }
        #endregion
        #region - Implementation of Interface -
        #endregion
        #region - Overrides -
        //protected override Task OnActivateAsync(CancellationToken cancellationToken)
        //{
        //    return base.OnActivateAsync(cancellationToken);
        //}

        protected override Task OnDeactivateAsync(bool close, CancellationToken cancellationToken)
        {
            _mediaPlayer?.Stop();
            //_mediaPlayer?.Dispose();
            _media?.Dispose();
            return base.OnDeactivateAsync(close, cancellationToken);
        }
        #endregion
        #region - Binding Methods -
        #endregion
        #region - Processes -
        private string GetDirectory()
        {
            string directoryPath = null;
            // 저장할 디렉터리의 절대 경로
            directoryPath = "C:\\Recordings";
            // 저장할 디렉터리의 절대 경로
            //directoryPath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location); ; 
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath); // 디렉터리가 없으면 생성
            }

            return directoryPath;
        }


        // 재생 메서드
        public Task Play(string rtspUrl, string deviceName = default, bool isRecording = false, string eventId = default
            , CancellationToken token = default)
        {
            return Task.Run(() =>
            {
                try
                {
                    if (!MediaPlayer.IsPlaying)
                    {
                        #region Other Options
                        //var options = new[]
                        //{
                        //    // 녹화 설정
                        //    $":sout=#duplicate{{dst=display,dst=transcode{{vcodec=h264,vb=800,acodec=mp4a,ab=128,channels=2,samplerate=44100}}:std{{access=file,mux=mp4,dst={destination}}}}}",
                        //    ":sout-keep"
                        //};
                        #endregion
                        string[] options = null;
                        if (isRecording)
                        {
                            var destination = Path.Combine(GetDirectory(), $"[{eventId}]{deviceName}.mp4");
                            options = new[]
                            {
                                $":sout=#duplicate{{" +
                                // Display RTSP설정
                                $"dst=display" +
                                // RTSP 영상 녹화 설정
                                $",dst=std{{access=file,mux=mp4,dst={destination}}}" +
                                // RTSP 스트리밍 설정
                                //$",dst=rtp{{sdp=rtsp://127.0.0.1:554/}}" +
                                //// 네트워크 캐시 사이즈
                                //$",network-caching=500" +
                                // DirectX Video Acceleration (DXVA) 2.0을 사용
                                $",avcodec-hw=dxva2" +
                                //
                                $",avcodec-threads=1" +
                                //$",avcodec-hw=vdpau" +
                                //$",avcodec-hw=vaapi" +
                                // 비디오 출력 모듈로 Direct3D 11을 사용합니다. GPU 가속을 활용하여 렌더링 성능을 향상
                                $",vout=direct3d11" +
                                //모든 비디오 필터를 비활성화
                                $",video-filter=non" +
                                // Direct3D 11 기반의 하드웨어 가속을 사용
                                $",direct3d11-hw-dec" +
                                //시스템 메모리를 사용하는 대신 Direct3D 디바이스를 통해 GPU 메모리를 사용
                                $",directx-use-sysmem" +
                                $"}}", ":sout-keep"
                            };
                        }
                        else
                        {
                            options = new[]
                            {
                                $":sout=#duplicate{{" +
                                // Display RTSP설정
                                $"dst=display" +
                                // RTSP 영상 녹화 설정
                                //$",dst=std{{access=file,mux=mp4,dst={destination}}}" +
                                // RTSP 스트리밍 설정
                                //$",dst=rtp{{sdp=rtsp://127.0.0.1:554/}}" +
                                //// 네트워크 캐시 사이즈
                                //$",network-caching=500" +
                                // DirectX Video Acceleration (DXVA) 2.0을 사용
                                $",avcodec-hw=dxva2" +
                                //
                                $",avcodec-threads=1" +
                                //$",avcodec-hw=vdpau" +
                                //$",avcodec-hw=vaapi" +
                                // 비디오 출력 모듈로 Direct3D 11을 사용합니다. GPU 가속을 활용하여 렌더링 성능을 향상
                                $",vout=direct3d11" +
                                //모든 비디오 필터를 비활성화
                                $",video-filter=non" +
                                // Direct3D 11 기반의 하드웨어 가속을 사용
                                $",direct3d11-hw-dec" +
                                //시스템 메모리를 사용하는 대신 Direct3D 디바이스를 통해 GPU 메모리를 사용
                                $",directx-use-sysmem" +
                                $"}}",
                                ":sout-keep"
                            };
                        }
                        if (token.IsCancellationRequested) throw new TaskCanceledException();
                        _media = new Media(_mediaPlayer.LibVLC
                            , new Uri(rtspUrl)
                            , options);

                        MediaPlayer.Play(_media);
                        PreparingCompleted?.Invoke(this, null);
                    }
                }
                catch (TaskCanceledException ex)
                {
                    Debug.WriteLine($"Raised {nameof(TaskCanceledException)} in {nameof(Play)} : {ex.Message}");
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Raised {nameof(Exception)} in {nameof(Play)} : {ex.Message}");
                }
            }, token);
        }

        // 정지 메서드
        public Task Stop()
        {
            return Task.Run(() =>
            {
                try
                {
                    MediaPlayer?.Stop();
                    _media?.Dispose();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Raised Exception in {nameof(Stop)} : {ex.Message}");
                }
            });

        }
        #endregion
        #region - IHanldes -
        #endregion
        #region - Properties -
        // MediaPlayer 속성
        public VlcMediaPlayer MediaPlayer
        {
            get => _mediaPlayer;
            set
            {
                if (_mediaPlayer != value)
                {
                    _mediaPlayer = value;
                    NotifyOfPropertyChange(nameof(MediaPlayer));
                }
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                NotifyOfPropertyChange(nameof(Name));
            }
        }
        public int? RowIndex { get; set; }
        public int? ColumnIndex { get; set; }
        #endregion
        #region - Attributes -
        private VlcMediaPlayer _mediaPlayer;
        private Media _media;
        private string _name;
        public event EventHandler PreparingCompleted;
        #endregion
    }
}
