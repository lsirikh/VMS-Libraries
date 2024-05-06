using Autofac;
using Dotnet.Libraries.LibVlcRtsp.UI.ViewModels;
using LibVLCSharp.Shared;

namespace Dotnet.Libraries.LibVlcRtsp.UI.Modules
{
    /****************************************************************************
        Purpose      :                                                           
        Created By   : GHLee                                                
        Created On   : 9/5/2023 8:25:14 AM                                                    
        Department   : SW Team                                                   
        Company      : Sensorway Co., Ltd.                                       
        Email        : lsirikh@naver.com                                         
     ****************************************************************************/

    public class MediaPlayerModule : Module
    {

        #region - Ctors -
        #endregion
        #region - Implementation of Interface -
        #endregion
        #region - Overrides -
        protected override void Load(ContainerBuilder builder)
        {
            try
            {
                builder.Register(ctx =>
                {
                    Core.Initialize();
                    string[] options = {
                        "--avcodec-hw=dxva2", // Windows의 경우 dxva2, Linux의 경우 vaapi 또는 vdpau 사용
                        "--vout=direct3d11", // Windows의 경우 direct3d11, 다른 플랫폼에서는 "gl" 사용 가능
                        "--network-caching=200", // 네트워크 캐싱 시간을 200ms로 설정
                        "--no-video-title-show", // 비디오 재생 시 타이틀 표시 안 함
                        "--directx-use-sysmem" // DirectX에서 GPU 메모리 사용
                    };
                    var libVlc = new LibVLC(options);
                    var mediaPlayer = new VlcMediaPlayer(libVlc);
                    return mediaPlayer;
                })
                .As<VlcMediaPlayer>();
                builder.RegisterType<VlcComponentViewModel>().InstancePerDependency();
            }
            catch
            {
                throw;
            }
        }
        #endregion
        #region - Binding Methods -
        #endregion
        #region - Processes -
        #endregion
        #region - IHanldes -
        #endregion
        #region - Properties -
        #endregion
        #region - Attributes -
        #endregion
    }
}
