using Autofac;
using Dotnet.Gstreamer.Transcoding.Services;
using Dotnet.Libraries.Base;
using System;

namespace Dotnet.Gstreamer.Transcoding.Modules;
/****************************************************************************
   Purpose      :                                                          
   Created By   : GHLee                                                
   Created On   : 5/9/2024 1:58:27 PM                                                    
   Department   : SW Team                                                   
   Company      : Sensorway Co., Ltd.                                       
   Email        : lsirikh@naver.com                                         
****************************************************************************/
public class TranscodingModule : Module
{
    #region - Ctors -
    public TranscodingModule(ILogService log = default)
    {
        _log = log;
    }
    #endregion
    #region - Implementation of Interface -
    #endregion
    #region - Overrides -
    protected override void Load(ContainerBuilder builder)
    {
        //builder.RegisterModule(new ApiModule(_log
        //    , new ApiSetupModel()
        //    {
        //        IpAddress = _setup.IpAddress,
        //        Port = _setup.Port,
        //        Username = _setup.Username,
        //        Password = _setup.Password,
        //    }));
        //builder.RegisterType<GlobalConfigurationModel>().SingleInstance();
        //builder.RegisterType<PathConfigProvider>().SingleInstance();
        //builder.RegisterType<PathProvider>().SingleInstance();

        _log?.Info($"{nameof(TranscodingModule)} is trying to create a single {nameof(TranscodingService)} instance.");
        builder.RegisterType<TranscodingService>().AsImplementedInterfaces()
            .SingleInstance().WithMetadata("Order", 3);


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
    private ILogService _log;
    #endregion
}