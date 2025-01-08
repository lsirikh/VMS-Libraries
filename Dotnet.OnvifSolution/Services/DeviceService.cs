using Autofac;
using Dotnet.Libraries.Base;
using Dotnet.OnvifSolution.Base.Enums;
using Dotnet.OnvifSolution.Base.Models;
using Dotnet.OnvifSolution.Base.Models.Components;
using Dotnet.OnvifSolution.Base.Models.Focuses;
using Dotnet.OnvifSolution.Base.Models.Profiles;
using Dotnet.OnvifSolution.Base.Models.Profiles.VideoSourceConfigs.VideoSource.Imaging;
using Dotnet.OnvifSolution.Base.Models.PTZPresets;
using Dotnet.OnvifSolution.Factories;
using Dotnet.OnvifSolution.Models;
using Dotnet.OnvifSolution.OnvifDeviceIo;
using Dotnet.OnvifSolution.OnvifDeviceMgmt;
using Dotnet.OnvifSolution.OnvifImaging;
using Dotnet.OnvifSolution.OnvifMedia;
using Dotnet.OnvifSolution.OnvifPtz;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace Dotnet.OnvifSolution.Services
{
    /****************************************************************************
        Purpose      :                                                           
        Created By   : GHLee                                                
        Created On   : 12/14/2023 10:58:17 AM                                                    
        Department   : SW Team                                                   
        Company      : Sensorway Co., Ltd.                                       
        Email        : lsirikh@naver.com                                         
     ****************************************************************************/

    internal class DeviceService : IDeviceService
    {
        #region - Ctors -
        public DeviceService(ILogService log = default)
        {
            _log = log;
        }
        #endregion
        #region - Implementation of Interface -
        #endregion
        #region - Overrides -
        #endregion
        #region - Binding Methods -
        #endregion
        #region - Processes -
        public async Task<CameraOnvifModel> InitializePreparing(IConnectionModel connectionModel)
        {

            try
            {
                if (connectionModel == null) throw new ArgumentNullException(nameof(connectionModel));
            }
            catch (Exception ex)
            {
                _log?.Error($"Raised Exception in {nameof(InitializePreparing)} of {nameof(DeviceService)} : {ex.Message}");
                return null;
            }

            OnvifConnectionModel onvifConnection = null;
            CameraOnvifModel onvifModel = null;

            try
            {
                onvifConnection = new OnvifConnectionModel(connectionModel);
                onvifModel = new CameraOnvifModel(connectionModel);

                onvifModel.DeviceClient = await ServiceFactory.CreateDeviceClientAsync(onvifConnection);

                if (onvifModel.DeviceClient == null) throw new Exception($"deviceClient was not created. Please check [Uri : {onvifConnection.Host}, Id : {onvifConnection.Username}, Pass: {onvifConnection.Password}]!");

                var info = await onvifModel.DeviceClient.GetDeviceInformationAsync(new OnvifDeviceIo.GetDeviceInformationRequest());
                if (info == null) throw new Exception($"Camera device specification was not fetched!");

                onvifModel.IsDevicePossible = true;

                onvifModel.Manufacturer = info.Manufacturer;
                onvifModel.DeviceModel = info.Model;
                onvifModel.FirmwareVersion = info.FirmwareVersion;
                onvifModel.SerialNumber = info.SerialNumber;
                onvifModel.HardwareId = info.HardwareId;

                return onvifModel;
            }
            catch (Exception ex)
            {
                onvifModel.CameraStatus = EnumCameraStatus.NOT_AVAILABLE;
                _log?.Error($"Raised Exception in {nameof(InitializePreparing)} of {nameof(DeviceService)} : {ex.Message}");
                return onvifModel;
            }
        }

        public async Task<CameraOnvifModel> InitializePreparing(ICameraDeviceModel cameraModel)
        {
            try
            {
                if (cameraModel == null) throw new ArgumentNullException(nameof(cameraModel));
            }
            catch (Exception ex)
            {
                _log?.Error($"Raised Exception in {nameof(InitializePreparing)} of {nameof(DeviceService)} : {ex.Message}");
                return null;
            }

            OnvifConnectionModel onvifConnection = null;
            CameraOnvifModel onvifModel = null;

            try
            {
                onvifConnection = new OnvifConnectionModel(cameraModel);
                onvifModel = new CameraOnvifModel(cameraModel);

                onvifModel.DeviceClient = await ServiceFactory.CreateDeviceClientAsync(onvifConnection);

                if (onvifModel.DeviceClient == null) throw new Exception($"deviceClient was not created. Please check [Uri : {onvifConnection.Host}, Id : {onvifConnection.Username}, Pass: {onvifConnection.Password}]!");

                onvifModel.IsDevicePossible = true;
                return onvifModel;
            }
            catch (Exception ex)
            {
                onvifModel.CameraStatus = EnumCameraStatus.NOT_AVAILABLE;
                _log?.Error($"Raised Exception in {nameof(InitializePreparing)} of {nameof(DeviceService)} : {ex.Message}");
                return onvifModel;
            }
        }


        /// <summary>
        /// 초기 Onvif 데이터 불러오기
        /// </summary>
        /// <param name="connectionModel"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<ICameraOnvifModel> InitializeOnvif(IConnectionModel connectionModel)
        {

            //_log.Info($">>>>InitializePreparing : {connectionModel.DeviceName}");
            if (connectionModel == null) throw new ArgumentNullException(nameof(connectionModel));

            var onvifConnection = new OnvifConnectionModel(connectionModel);

            var onvifModel = await InitializePreparing(connectionModel);
            await Task.Delay(500);
            if (onvifModel.CameraStatus == EnumCameraStatus.NOT_AVAILABLE)
                return onvifModel;
            return await GenerateOnvifModel(onvifModel, onvifConnection);
        }

        /// <summary>
        /// 초기 Onvif 데이터 불러오기
        /// </summary>
        /// <param name="cameraModel"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<ICameraOnvifModel> InitializeOnvif(ICameraDeviceModel cameraModel)
        {

            //_log.Info($">>>>InitializePreparing : {cameraModel.DeviceName}");
            if (cameraModel == null) throw new ArgumentNullException(nameof(cameraModel));
            var onvifConnection = new OnvifConnectionModel(cameraModel);

            var onvifModel = await InitializePreparing(cameraModel);
            if(onvifModel.CameraStatus == EnumCameraStatus.NOT_AVAILABLE)
                return onvifModel;

            return await GenerateOnvifModel(onvifModel, onvifConnection);
        }

        private async Task<ICameraOnvifModel> GenerateOnvifModel(CameraOnvifModel onvifModel, IOnvifConnectionModel onvifConnection)
        {
            string errorMsg = $"Please check [Uri : {onvifConnection.Host}, Id : {onvifConnection.Username}, Pass: {onvifConnection.Password}]!";

            try
            {
                onvifModel.Type = EnumCameraType.FIXED_CAMERA;
                onvifModel.PtzClient = await ServiceFactory.CreatePTZClientAsync(onvifConnection);
                await Task.Delay(10);
                if (onvifModel.PtzClient == null) throw new NullReferenceException($"Ptz was not created. {errorMsg}");
                onvifModel.IsPtzPossible = true;
                onvifModel.Type = EnumCameraType.PTZ_CAMERA;
            }
            catch (NullReferenceException)
            {
                onvifModel.Type = EnumCameraType.FIXED_CAMERA;
                //_log?.Info($"Raised Exception in {nameof(GenerateOnvifModel)} of {nameof(DeviceService)} : {ex.Message}");
            }  
            catch (Exception)
            {
                //_log?.Error($"Raised Exception in {nameof(GenerateOnvifModel)} : {ex.Message}");
            }

            
            try
            {
                onvifModel.ImagingClient = await ServiceFactory.CreateImagingClientAsync(onvifConnection);
                await Task.Delay(10);
                if (onvifModel.ImagingClient == null) throw new NullReferenceException($"Imaging was not created. {errorMsg}");
                onvifModel.IsImagingPossible = true;
            }
            catch (NullReferenceException)
            {
                //_log?.Error($"Raised Exception in {nameof(GenerateOnvifModel)} of {nameof(DeviceService)} : {ex.Message}");
            }
            catch (Exception)
            {
                //_log?.Error($"Raised Exception in {nameof(GenerateOnvifModel) : {ex.Message}");
            }
            
            try
            {
                onvifModel.MediaClient = await ServiceFactory.CreateMediaClientAsync(onvifConnection);
                await Task.Delay(10);
                if (onvifModel.MediaClient == null) throw new NullReferenceException($"Media was not created. {errorMsg}");
                onvifModel.IsMediaPossible = true;
            }
            catch (NullReferenceException)
            {
                // _log?.Error($"Raised Exception in {nameof(GenerateOnvifModel)} of {nameof(DeviceService)} : {ex.Message}");
                return null;
            }
            catch (Exception ex)
            {
                //_log?.Error($"Raised Exception in {nameof(GenerateOnvifModel)} of {nameof(DeviceService)} : {ex.Message}");
                return null;
            }
            

            onvifModel.Profiles = (await onvifModel.MediaClient?.GetProfilesAsync())?.Profiles?.ToList();
            await Task.Delay(10);
            //_log.Info($">>>>{onvifModel.DeviceName} GetProfilesAsync  : {onvifModel.Profiles.Count()}");
            onvifModel.CameraMedia.Token = onvifModel.Profiles?.FirstOrDefault()?.token;

            onvifModel.CameraMedia?.Profiles?.Clear();
            foreach (var profile in onvifModel?.Profiles)
            {
                var cameraProfile = new CameraProfile();

                try
                {
                    cameraProfile.Name = profile.Name;
                    cameraProfile.Token = profile.token;
                    cameraProfile.Fixed = profile.@fixed;

                    //Profile Streaming URL
                    cameraProfile = await GetProfileStreamUrl(cameraProfile, profile.token, onvifModel);
                    await Task.Delay(10);

                    //VideoSourceConfiguration
                    if (profile?.VideoSourceConfiguration != null)
                    {
                        cameraProfile.VideoSourceConfig = new Base.Models.Profiles.VideoSourceConfigs.VideoSourceConfigModel();

                        cameraProfile.VideoSourceConfig.Name = profile?.VideoSourceConfiguration?.Name;
                        cameraProfile.VideoSourceConfig.Token = profile?.VideoSourceConfiguration?.SourceToken;
                        cameraProfile.VideoSourceConfig.UseCount = (int)profile?.VideoSourceConfiguration?.UseCount;
                        cameraProfile.VideoSourceConfig.Bounds = new List<int>
                        {
                            (int)profile?.VideoSourceConfiguration?.Bounds.x,
                            (int)profile?.VideoSourceConfiguration?.Bounds.y,
                            (int)profile?.VideoSourceConfiguration?.Bounds.width,
                            (int)profile?.VideoSourceConfiguration?.Bounds.height,
                        };
                        cameraProfile.VideoSourceConfig.Token = profile?.VideoSourceConfiguration?.SourceToken;

                        cameraProfile = await GetVideoSource(cameraProfile, onvifModel);
                        await Task.Delay(50);
                    }

                    //AudioSourceConfiguration
                    if (profile.AudioSourceConfiguration != null)
                    {
                        cameraProfile.AudioSourceConfig = new Base.Models.Profiles.AudioSourceConfigs.AudioSourceConfigModel();

                        cameraProfile.AudioSourceConfig.Name = profile.AudioSourceConfiguration?.Name;
                        cameraProfile.AudioSourceConfig.Token = profile.AudioSourceConfiguration?.token;
                        cameraProfile.AudioSourceConfig.UseCount = (int)profile.AudioSourceConfiguration?.UseCount;

                        cameraProfile = await GetAudioSource(cameraProfile, onvifModel);
                        await Task.Delay(10);
                    }


                    //VideoEncoderConfiguration
                    cameraProfile = GetVideoEncoderConfig(cameraProfile, profile.VideoEncoderConfiguration);
                    //AudioEncoderConfiguration
                    cameraProfile = GetAudioEncoderConfig(cameraProfile, profile.AudioEncoderConfiguration);
                    //VideoAnalyticsConfiguration
                    cameraProfile = GetVideoAnalyticsConfig(cameraProfile, profile.VideoAnalyticsConfiguration);
                    //MetadataConfiguration
                    cameraProfile = GetMetadataConfig(cameraProfile, profile.MetadataConfiguration);
                    //PTZConfiguration
                    cameraProfile = await GetPTZConfig(cameraProfile, onvifModel);
                    await Task.Delay(10);
                    //Add Profile to Profiles in the CameraMedia instance.
                    onvifModel.CameraMedia.Profiles.Add(cameraProfile);
                }
                catch
                {
                }
            }

            try
            {
                if (onvifModel.Type == EnumCameraType.PTZ_CAMERA)
                {
                    await GetPTZPreset(onvifModel.CameraMedia, onvifModel.PtzClient, onvifModel.CameraMedia.Token);
                }
            }
            catch 
            {
            }

            onvifModel.CameraStatus = EnumCameraStatus.AVAILABLE;

            return onvifModel;
        }


        /// <summary>
        /// 프로파일 별로 URL을 가져오는 메소드
        /// </summary>
        /// <param name="cameraProfile"></param>
        /// <param name="token"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        private async Task<CameraProfile> GetProfileStreamUrl(CameraProfile cameraProfile, string token, CameraOnvifModel model)
        {
            try
            {
                var streamSetup = new StreamSetup
                {
                    Stream = StreamType.RTPUnicast,  // 또는 RTPMulticast
                    Transport = new Transport
                    {
                        Protocol = TransportProtocol.RTSP
                    }
                };
                MediaUri stream = await model?.MediaClient?.GetStreamUriAsync(streamSetup, token);
                if (stream != null)
                {

                    cameraProfile.MediaUri = new Base.Models.Components.MediaUriModel();
                    cameraProfile.MediaUri.Uri = stream.Uri;
                    cameraProfile.MediaUri.InvalidAfterConnect = stream.InvalidAfterConnect;
                    cameraProfile.MediaUri.InvalidAfterReboot = stream.InvalidAfterReboot;
                    cameraProfile.MediaUri.Timeout = stream.Timeout;
                }
            }
            catch (ArgumentNullException)
            {

            }
            catch (Exception ex)
            {
                _log?.Error($"Raised Exception in {nameof(GetProfileStreamUrl)} of {nameof(DeviceService)} : {ex.Message}");
            }

            return cameraProfile;
        }

        /// <summary>
        /// VideoAnalyticsConfig 가져오는 메소드
        /// </summary>
        /// <param name="cameraProfile"></param>
        /// <param name="videoAnalyticsConfiguration"></param>
        /// <returns></returns>
        private CameraProfile GetVideoAnalyticsConfig(CameraProfile cameraProfile, OnvifMedia.VideoAnalyticsConfiguration videoAnalyticsConfiguration)
        {
            try
            {
                if (videoAnalyticsConfiguration == null) throw new NullReferenceException($"{nameof(OnvifMedia.VideoAnalyticsConfiguration)} is not exist.");

                cameraProfile.VideoAnalyticsConfig = new Base.Models.Profiles.VideoAnalyticConfigs.VideoAnalyticsConfigModel();
                cameraProfile.VideoAnalyticsConfig.Name = videoAnalyticsConfiguration.Name;
                cameraProfile.VideoAnalyticsConfig.Token = videoAnalyticsConfiguration.token;
                cameraProfile.VideoAnalyticsConfig.UseCount = videoAnalyticsConfiguration.UseCount;

                foreach (var item in videoAnalyticsConfiguration.AnalyticsEngineConfiguration.AnalyticsModule)
                {
                    cameraProfile.VideoAnalyticsConfig.Analytics.Add(item.Name);
                }

                foreach (var item in videoAnalyticsConfiguration.RuleEngineConfiguration.Rule)
                {
                    cameraProfile.VideoAnalyticsConfig.Analytics.Add(item.Name);
                }
            }
            catch (NullReferenceException)
            {
                
            }
            catch (Exception ex)
            {
                _log?.Error($"Raised Exception in {nameof(GetVideoAnalyticsConfig)} of {nameof(DeviceService)} : {ex.Message}");
            }

            return cameraProfile;
        }

        /// <summary>
        /// AudioEncodingConfig 가져오는 메소드
        /// </summary>
        /// <param name="cameraProfile"></param>
        /// <param name="audioEncoderConfiguration"></param>
        /// <returns></returns>
        private CameraProfile GetAudioEncoderConfig(CameraProfile cameraProfile, OnvifMedia.AudioEncoderConfiguration audioEncoderConfiguration)
        {
            try
            {
                if (audioEncoderConfiguration == null) throw new NullReferenceException($"{nameof(OnvifMedia.AudioEncoderConfiguration)} is not exist.");

                cameraProfile.AudioEncoderConfig = new Base.Models.Profiles.AudioEncoderConfigs.AudioEncoderConfigModel();
                cameraProfile.AudioEncoderConfig.Name = audioEncoderConfiguration.Name;
                cameraProfile.AudioEncoderConfig.Token = audioEncoderConfiguration.token;
                cameraProfile.AudioEncoderConfig.UseCount = audioEncoderConfiguration.UseCount;
                cameraProfile.AudioEncoderConfig.Encoding =
                    (EnumAudioEncoding)audioEncoderConfiguration.Encoding;
                cameraProfile.AudioEncoderConfig.Bitrate = audioEncoderConfiguration.Bitrate;
                cameraProfile.AudioEncoderConfig.SampleRate = audioEncoderConfiguration.SampleRate;
                cameraProfile.AudioEncoderConfig.SessionTimeout = audioEncoderConfiguration.SessionTimeout;

                if (audioEncoderConfiguration.Multicast == null) return cameraProfile;
                cameraProfile.AudioEncoderConfig.MultiCast = new Base.Models.Components.MultiCastModel();
                cameraProfile.AudioEncoderConfig.MultiCast.IpAddress = audioEncoderConfiguration.Multicast.Address.IPv4Address;
                cameraProfile.AudioEncoderConfig.MultiCast.Port = audioEncoderConfiguration.Multicast.Port;
                cameraProfile.AudioEncoderConfig.MultiCast.Ttl = audioEncoderConfiguration.Multicast.TTL;
                cameraProfile.AudioEncoderConfig.MultiCast.AutoStart = audioEncoderConfiguration.Multicast.AutoStart;
            }
            catch (NullReferenceException)
            {
            }
            catch (Exception ex)
            {
                _log?.Error($"Raised Exception in {nameof(GetAudioEncoderConfig)} of {nameof(DeviceService)} : {ex.Message}");
            }
            return cameraProfile;
        }

        /// <summary>
        /// VideoEncodingConfig를 갖고오는 메소드
        /// </summary>
        /// <param name="cameraProfile"></param>
        /// <param name="videoEncoderConfiguration"></param>
        /// <returns></returns>
        private CameraProfile GetVideoEncoderConfig(CameraProfile cameraProfile, OnvifMedia.VideoEncoderConfiguration videoEncoderConfiguration)
        {
            try
            {
                if (videoEncoderConfiguration == null) throw new NullReferenceException($"{nameof(OnvifMedia.VideoEncoderConfiguration)} is not exist.");

                cameraProfile.VideoEncoderConfig = new Base.Models.Profiles.VideoEncoderConfigs.VideoEncoderConfigModel();
                cameraProfile.VideoEncoderConfig.Name = videoEncoderConfiguration.Name;
                cameraProfile.VideoEncoderConfig.Token = videoEncoderConfiguration.token;
                cameraProfile.VideoEncoderConfig.UseCount = videoEncoderConfiguration.UseCount;
                cameraProfile.VideoEncoderConfig.Encoding =
                    (EnumVideoEncoding)videoEncoderConfiguration.Encoding;
                cameraProfile.VideoEncoderConfig.Resolution.Width = videoEncoderConfiguration.Resolution.Width;
                cameraProfile.VideoEncoderConfig.Resolution.Height = videoEncoderConfiguration.Resolution.Height;
                cameraProfile.VideoEncoderConfig.SessionTimeout = videoEncoderConfiguration.SessionTimeout;
                cameraProfile.VideoEncoderConfig.Quality = videoEncoderConfiguration.Quality;
                cameraProfile.VideoEncoderConfig.FrameRate = videoEncoderConfiguration.RateControl.FrameRateLimit;
                cameraProfile.VideoEncoderConfig.Bitrate = videoEncoderConfiguration.RateControl.BitrateLimit;
                cameraProfile.VideoEncoderConfig.EncodingInterval = videoEncoderConfiguration.RateControl.EncodingInterval;
                cameraProfile.VideoEncoderConfig.MultiCast.IpAddress = videoEncoderConfiguration.Multicast.Address.IPv4Address;
                cameraProfile.VideoEncoderConfig.MultiCast.Port = videoEncoderConfiguration.Multicast.Port;
                cameraProfile.VideoEncoderConfig.MultiCast.Ttl = videoEncoderConfiguration.Multicast.TTL;
                cameraProfile.VideoEncoderConfig.MultiCast.AutoStart = videoEncoderConfiguration.Multicast.AutoStart;
            }
            catch (NullReferenceException)
            {

            }
            catch (Exception ex)
            {
                _log?.Error($"Raised Exception in {nameof(GetVideoEncoderConfig)} of {nameof(DeviceService)} : {ex.Message}");
            }
            return cameraProfile;
        }

        private async Task<CameraProfile> GetAudioSource(CameraProfile cameraProfile, CameraOnvifModel model)
        {
            try
            {

                if (model == null || model.MediaClient == null) throw new NullReferenceException($"{nameof(OnvifMedia.MediaClient)} is not exist.");

                var audioSources = await model.MediaClient.GetAudioSourcesAsync();

                if (audioSources != null)
                {
                    cameraProfile.AudioSourceConfig.AudioSource = new Base.Models.Profiles.AudioSourceConfigs.AudioSource.AudioSourceModel();
                    foreach (var item in audioSources.AudioSources)
                    {
                        cameraProfile.AudioSourceConfig.AudioSource.Token = item.token;
                        cameraProfile.AudioSourceConfig.AudioSource.Channels = item.Channels;
                    }

                }
            }
            catch (NullReferenceException)
            {
            }
            catch (Exception ex)
            {
                _log?.Error($"Raised Exception in {nameof(GetAudioSource)} of {nameof(DeviceService)} : {ex.Message}");
            }

            return cameraProfile;
        }

        /// <summary>
        /// VideoSource를 가져오는 메소드
        /// </summary>
        /// <param name="cameraProfile"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        private async Task<CameraProfile> GetVideoSource(CameraProfile cameraProfile, CameraOnvifModel model)
        {
            try
            {
                if (model == null || model.MediaClient == null) throw new NullReferenceException($"{nameof(OnvifMedia.MediaClient)} is not exist.");

                var mediaClient = model.MediaClient;
                var video_sources = await mediaClient.GetVideoSourcesAsync();
                //string vsource_token = null;

                foreach (var source in video_sources.VideoSources)
                {

                    if (model.CameraMedia.ProfileTitle == null)
                        model.CameraMedia.ProfileTitle = $"{source.token}:{cameraProfile.Name}";

                    //OnvifImaging.ImagingSettings20 imaging = null;
                    //if (source.Imaging == null)
                    //    imaging = await onvifModel.ImagingClient?.GetImagingSettingsAsync(source.token);


                    cameraProfile.VideoSourceConfig.VideoSource.Token = source.token;
                    cameraProfile.VideoSourceConfig.VideoSource.FrameRate = source.Framerate;
                    cameraProfile.VideoSourceConfig.VideoSource.Resolution.Width = source.Resolution.Width;
                    cameraProfile.VideoSourceConfig.VideoSource.Resolution.Height = source.Resolution.Height;

                    if (source.Imaging == null) return cameraProfile;

                    cameraProfile.VideoSourceConfig.VideoSource.ImagingOption = new Base.Models.Profiles.VideoSourceConfigs.VideoSource.Imaging.ImagingOptionModel();
                    /////////////////////Focus/////////////////////////
                    if (source.Imaging?.Focus != null)
                    {
                        // Focus
                        cameraProfile.VideoSourceConfig.VideoSource.ImagingOption.Focus.AutoFocusMode =
                            (EnumAutoFocusMode)source.Imaging.Focus.AutoFocusMode;
                        cameraProfile.VideoSourceConfig.VideoSource.ImagingOption.Focus.NearLimit =
                            source.Imaging.Focus.NearLimit;
                        cameraProfile.VideoSourceConfig.VideoSource.ImagingOption.Focus.FarLimit =
                            source.Imaging.Focus.FarLimit;
                        cameraProfile.VideoSourceConfig.VideoSource.ImagingOption.Focus.DefaultSpeed =
                            source.Imaging.Focus.DefaultSpeed;
                    }


                    /////////////////////Exposure/////////////////////////
                    if (source.Imaging?.Exposure != null)
                    {

                        //Exposure
                        cameraProfile.VideoSourceConfig.VideoSource.ImagingOption.Exposure.Mode =
                            (EnumExposureMode)source.Imaging.Exposure.Mode;
                        cameraProfile.VideoSourceConfig.VideoSource.ImagingOption.Exposure.IrisRange.Min =
                            source.Imaging.Exposure.MinIris;
                        cameraProfile.VideoSourceConfig.VideoSource.ImagingOption.Exposure.IrisRange.Max =
                            source.Imaging.Exposure.MaxIris;

                        cameraProfile.VideoSourceConfig.VideoSource.ImagingOption.Exposure.ExposureTime = source.Imaging.Exposure.ExposureTime;
                        cameraProfile.VideoSourceConfig.VideoSource.ImagingOption.Exposure.ExposureTimeRange.Min = source.Imaging.Exposure.MinExposureTime;
                        cameraProfile.VideoSourceConfig.VideoSource.ImagingOption.Exposure.ExposureTimeRange.Max = source.Imaging.Exposure.MaxExposureTime;

                        cameraProfile.VideoSourceConfig.VideoSource.ImagingOption.Exposure.Gain = source.Imaging.Exposure.Gain;
                        cameraProfile.VideoSourceConfig.VideoSource.ImagingOption.Exposure.GainRange.Min = source.Imaging.Exposure.MinGain;
                        cameraProfile.VideoSourceConfig.VideoSource.ImagingOption.Exposure.GainRange.Max = source.Imaging.Exposure.MaxGain;

                    }


                    //Imaging Other Options
                    if (model.ImagingClient == null) return cameraProfile;

                    var imaging_opts = await model.ImagingClient?.GetOptionsAsync(source.token);
                    cameraProfile.VideoSourceConfig.VideoSource.ImagingOption.Brightness =
                        source.Imaging.Brightness;
                    cameraProfile.VideoSourceConfig.VideoSource.ImagingOption.ColorSaturation =
                        source.Imaging.ColorSaturation;
                    cameraProfile.VideoSourceConfig.VideoSource.ImagingOption.Sharpness =
                        source.Imaging.Sharpness;
                    cameraProfile.VideoSourceConfig.VideoSource.ImagingOption.Contrast =
                        source.Imaging.Contrast;
                    cameraProfile.VideoSourceConfig.VideoSource.ImagingOption.IrCutFilter =
                        (EnumIrCutFilterMode)source.Imaging.IrCutFilter;




                    if (imaging_opts != null)
                    {
                        cameraProfile.VideoSourceConfig.VideoSource.ImagingOption.BrightnessRange.Min =
                            imaging_opts.Brightness.Min;
                        cameraProfile.VideoSourceConfig.VideoSource.ImagingOption.BrightnessRange.Max =
                            imaging_opts.Brightness.Max;
                        cameraProfile.VideoSourceConfig.VideoSource.ImagingOption.ColorSaturationRange.Max =
                            imaging_opts.ColorSaturation.Max;
                        cameraProfile.VideoSourceConfig.VideoSource.ImagingOption.ColorSaturationRange.Min =
                            imaging_opts.ColorSaturation.Min;
                        cameraProfile.VideoSourceConfig.VideoSource.ImagingOption.SharpnessRange.Min =
                            imaging_opts.Sharpness.Min;
                        cameraProfile.VideoSourceConfig.VideoSource.ImagingOption.SharpnessRange.Max =
                            imaging_opts.Sharpness.Max;
                        cameraProfile.VideoSourceConfig.VideoSource.ImagingOption.ContrastRange.Min =
                            imaging_opts.Contrast.Min;
                        cameraProfile.VideoSourceConfig.VideoSource.ImagingOption.ContrastRange.Max =
                            imaging_opts.Sharpness.Max;
                    }


                    //BacklightCompensation
                    if (source.Imaging.BacklightCompensation != null)
                    {
                        cameraProfile.VideoSourceConfig.VideoSource.ImagingOption.BacklightCompensation.Level = source.Imaging.BacklightCompensation.Level;
                    }

                    if (imaging_opts.BacklightCompensation != null)
                    {

                        if (imaging_opts.BacklightCompensation.Level != null)
                        {
                            cameraProfile.VideoSourceConfig.VideoSource.ImagingOption.BacklightCompensation.LevelRange.Max =
                                imaging_opts.BacklightCompensation.Level.Max;
                            cameraProfile.VideoSourceConfig.VideoSource.ImagingOption.BacklightCompensation.LevelRange.Min =
                                imaging_opts.BacklightCompensation.Level.Min;
                        }

                        foreach (var item in imaging_opts.BacklightCompensation.Mode?.ToList())
                        {
                            cameraProfile.VideoSourceConfig.VideoSource.ImagingOption.BacklightCompensation.Mode =
                                (EnumBacklightCompensationMode)item;
                        }
                    }

                    if (source.Imaging.WhiteBalance != null)
                    {
                        //WhiteBalance
                        cameraProfile.VideoSourceConfig.VideoSource.ImagingOption.WhiteBalance.YbGain =
                            source.Imaging.WhiteBalance.CbGain;
                        cameraProfile.VideoSourceConfig.VideoSource.ImagingOption.WhiteBalance.YrGain =
                            source.Imaging.WhiteBalance.CrGain;
                        cameraProfile.VideoSourceConfig.VideoSource.ImagingOption.WhiteBalance.Mode =
                            (EnumWhiteBalanceMode)source.Imaging.WhiteBalance.Mode;
                    }

                    if (source.Imaging.WideDynamicRange != null)
                    {
                        //Wide Dynamic Range
                        cameraProfile.VideoSourceConfig.VideoSource.ImagingOption.WideDynamicRange.Level =
                        source.Imaging.WideDynamicRange.Level;
                        cameraProfile.VideoSourceConfig.VideoSource.ImagingOption.WideDynamicRange.Mode = (EnumWideDynamicMode)source.Imaging.WideDynamicRange.Mode;
                    }
                }
            }
            catch (NullReferenceException)
            {

            }
            catch (TaskCanceledException ex)
            {
                _log?.Error($"Raised Exception in {nameof(GetVideoSource)} of {nameof(DeviceService)} : {ex.Message}");
            }
            return cameraProfile;
        }

        /// <summary>
        /// 메타데이터 가져오는 Config
        /// </summary>
        /// <param name="cameraProfile"></param>
        /// <param name="metadataConfiguration"></param>
        /// <returns></returns>
        private CameraProfile GetMetadataConfig(CameraProfile cameraProfile, OnvifMedia.MetadataConfiguration metadataConfiguration)
        {
            try
            {
                if (metadataConfiguration == null) throw new NullReferenceException($"{nameof(OnvifMedia.MetadataConfiguration)} is not exist.");

                cameraProfile.MetadataConfig = new Base.Models.Profiles.MetadataConfigs.MetadataConfigModel();
                cameraProfile.MetadataConfig.Name = metadataConfiguration.Name;
                cameraProfile.MetadataConfig.Token = metadataConfiguration.token;
                cameraProfile.MetadataConfig.UseCount = metadataConfiguration.UseCount;
                cameraProfile.MetadataConfig.SessionTimeout = metadataConfiguration.SessionTimeout;
                cameraProfile.MetadataConfig.Analytics = metadataConfiguration.Analytics;
                cameraProfile.MetadataConfig.CompressionType = metadataConfiguration.CompressionType;
                cameraProfile.MetadataConfig.GeoLocation = metadataConfiguration.GeoLocation;
                cameraProfile.MetadataConfig.ShapePolygon = metadataConfiguration.ShapePolygon;

                if (metadataConfiguration.PTZStatus != null)
                {
                    cameraProfile.MetadataConfig.PTZStatus = new Base.Models.Components.PTZFilterModel();
                    cameraProfile.MetadataConfig.PTZStatus.Status = metadataConfiguration.PTZStatus.Status;
                    cameraProfile.MetadataConfig.PTZStatus.Position = metadataConfiguration.PTZStatus.Position;
                }

                if (metadataConfiguration.Events != null)
                {
                    cameraProfile.MetadataConfig.EventSubscription = new Base.Models.Components.EventSubscriptionModel();
                    if (metadataConfiguration.Events.Filter != null)
                    {
                        cameraProfile.MetadataConfig.EventSubscription.Filter = new Base.Models.Components.FilterTypeModel();
                        foreach (var item in metadataConfiguration.Events.Filter.Any)
                        {
                            cameraProfile.MetadataConfig.EventSubscription.Filter.Any.Add(item);
                        }
                    }

                    if (metadataConfiguration.Events.SubscriptionPolicy != null)
                    {
                        cameraProfile.MetadataConfig.EventSubscription.SubscriptionPolicy = new Base.Models.Components.FilterTypeModel();
                        foreach (var item in metadataConfiguration.Events.SubscriptionPolicy?.Any)
                        {
                            cameraProfile.MetadataConfig.EventSubscription.SubscriptionPolicy.Any.Add(item);
                        }
                    }
                }

                if (metadataConfiguration.Multicast != null)
                {
                    cameraProfile.MetadataConfig.MultiCast = new Base.Models.Components.MultiCastModel();
                    cameraProfile.MetadataConfig.MultiCast.IpAddress = metadataConfiguration.Multicast.Address.IPv4Address;

                    cameraProfile.MetadataConfig.MultiCast.Port = metadataConfiguration.Multicast.Port;
                    cameraProfile.MetadataConfig.MultiCast.Ttl = metadataConfiguration.Multicast.TTL;
                    cameraProfile.MetadataConfig.MultiCast.AutoStart = metadataConfiguration.Multicast.AutoStart;
                }

            }
            catch (NullReferenceException)
            {

            }
            catch (Exception ex)
            {
                _log?.Error($"Raised Exception in {nameof(GetMetadataConfig)} of {nameof(DeviceService)} : {ex.Message}");
            }
            return cameraProfile;
        }

        /// <summary>
        /// PTZConfig 정보를 갖고 오는 메소드
        /// </summary>
        /// <param name="cameraProfile"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        private async Task<CameraProfile> GetPTZConfig(CameraProfile cameraProfile, CameraOnvifModel model)
        {
            try
            {
                //PTZConfiguration
                if (model.PtzClient == null) return cameraProfile;

                var ptzClient = model.PtzClient;
                
                var configs = await ptzClient?.GetConfigurationsAsync();
                if (configs == null) return cameraProfile;

                cameraProfile.PTZConfig = new Base.Models.Profiles.PtzConfigs.PTZConfigModel();
                foreach (var item in configs.PTZConfiguration)
                {
                    cameraProfile.PTZConfig.Name = item.Name;
                    cameraProfile.PTZConfig.Token = item.token;
                    cameraProfile.PTZConfig.UseCount = item.UseCount;

                    if (item.PanTiltLimits != null && item.PanTiltLimits.Range != null)
                    {
                        cameraProfile.PTZConfig.PanTiltRange.XRange.Min = item.PanTiltLimits.Range.XRange.Min;
                        cameraProfile.PTZConfig.PanTiltRange.XRange.Max = item.PanTiltLimits.Range.XRange.Max;
                        cameraProfile.PTZConfig.PanTiltRange.YRange.Min = item.PanTiltLimits.Range.YRange.Min;
                        cameraProfile.PTZConfig.PanTiltRange.YRange.Max = item.PanTiltLimits.Range.YRange.Max;
                        cameraProfile.PTZConfig.PanTiltRange.Uri = item.PanTiltLimits.Range.URI;
                        cameraProfile.PTZConfig.ZoomRange.XRange.Min = item.ZoomLimits.Range.XRange.Min;
                        cameraProfile.PTZConfig.ZoomRange.XRange.Max = item.ZoomLimits.Range.XRange.Max;
                        cameraProfile.PTZConfig.ZoomRange.Uri = item.ZoomLimits.Range.URI;
                    }

                    if (item.PanTiltLimits != null )
                    {
                        if(item.DefaultPTZSpeed.PanTilt != null)
                        {
                            cameraProfile.PTZConfig.DefaultPTZSpeed.PanTilt.X = item.DefaultPTZSpeed.PanTilt.x;
                            cameraProfile.PTZConfig.DefaultPTZSpeed.PanTilt.Y = item.DefaultPTZSpeed.PanTilt.y;
                            cameraProfile.PTZConfig.DefaultPTZSpeed.PanTilt.Space = item.DefaultPTZSpeed.PanTilt.space;
                        }
                        if (item.DefaultPTZSpeed.Zoom != null)
                        { 
                            cameraProfile.PTZConfig.DefaultPTZSpeed.Zoom.X = item.DefaultPTZSpeed.Zoom.x;
                            cameraProfile.PTZConfig.DefaultPTZSpeed.Zoom.Space = item.DefaultPTZSpeed.Zoom.space;
                        }
                    }

                    cameraProfile.PTZConfig.Timeout = item?.DefaultPTZTimeout;

                    cameraProfile.PTZConfig.DefaultAbsolutePantTiltPositionSpace =
                        item?.DefaultAbsolutePantTiltPositionSpace;
                    cameraProfile.PTZConfig.DefaultAbsoluteZoomPositionSpace =
                        item?.DefaultAbsoluteZoomPositionSpace;

                    cameraProfile.PTZConfig.DefaultContinuousPanTiltVelocitySpace =
                        item?.DefaultContinuousPanTiltVelocitySpace;
                    cameraProfile.PTZConfig.DefaultContinuousZoomVelocitySpace =
                        item?.DefaultContinuousZoomVelocitySpace;

                    cameraProfile.PTZConfig.DefaultRelativePanTiltTranslationSpace =
                        item?.DefaultRelativePanTiltTranslationSpace;
                    cameraProfile.PTZConfig.DefaultRelativeZoomTranslationSpace =
                        item?.DefaultRelativeZoomTranslationSpace;

                    var node = await ptzClient.GetNodeAsync(item.NodeToken);
                    if(node != null) 
                    { 
                        cameraProfile.PTZConfig.PTZNode.Name = node.Name;
                        cameraProfile.PTZConfig.PTZNode.Token = node.token;
                        cameraProfile.PTZConfig.PTZNode.HomeSupported = node.HomeSupported;
                        cameraProfile.PTZConfig.PTZNode.MaximumNumberOfPresets = node.MaximumNumberOfPresets;

                        //cameraProfile.PTZConfig.PTZNode.SupportedPTZSpaces = node.SupportedPTZSpaces;

                        if (node.AuxiliaryCommands == null) continue;

                        foreach (var innerItem in node.AuxiliaryCommands)
                        {
                            cameraProfile.PTZConfig.PTZNode.AuxiliaryCommands.Add(innerItem);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                _log?.Error($"Raised Exception in {nameof(GetPTZConfig)} of {nameof(DeviceService)} : {ex.Message}");

            }
            return cameraProfile;
        }

        public async Task<bool> GetPTZPreset(CameraMediaModel model, PTZClient ptzClient, string token)
        {
            if (ptzClient == null) return false;

            try
            {
                var presets = await ptzClient.GetPresetsAsync(token);
                model.PTZPresets.Clear();
                if (presets == null || presets.Preset == null) return false;

                foreach (var item in presets?.Preset)
                {
                    var preset = new PTZPresetModel()
                    {
                        Name = item.Name,
                        Token = item.token,
                    };

                    if (item.PTZPosition == null) continue;

                    if (item.PTZPosition.PanTilt == null) continue;
                    var panTilt = new Vector2DModel()
                    {
                        X = item.PTZPosition.PanTilt.x,
                        Y = item.PTZPosition.PanTilt.y,
                        Space = item.PTZPosition.PanTilt.space
                    };

                    if (item.PTZPosition.Zoom == null) continue;
                    var zoom = new Vector1DModel()
                    {
                        X = item.PTZPosition.Zoom.x,
                        Space = item.PTZPosition.Zoom.space
                    };

                    preset.PTZPosition.PanTilt = panTilt;
                    preset.PTZPosition.Zoom = zoom;
                    model.PTZPresets.Add(preset);

                    //_log?.Info($"Name : {item.Name}, Preset Token : {item.token}, PanTilt : ({item.PTZPosition.PanTilt.x},{item.PTZPosition.PanTilt.y}), Zoom : {item.PTZPosition.Zoom.x}");
                }
                return true;
            }
            catch (Exception ex)
            {
                _log?.Error($"Raised Exception in {nameof(GetPTZPreset)} of {nameof(DeviceService)} : {ex.Message}");
                return false;
            }
        }

        public async Task<bool> GoPTZPreset(PTZClient ptzClient, PTZSpeedModel pTZSpeed, string profileToken, string presetToken)
        {
            try
            {
                var ptzSpeed = GetPTZSpeedInstance(pTZSpeed);
                await ptzClient.GotoPresetAsync(profileToken, presetToken, ptzSpeed);
                return true;
            }
            catch (Exception ex)
            {
                _log?.Error($"Raised Exception in {nameof(GoPTZPreset)} of {nameof(DeviceService)} : {ex.Message}");
                return false;
            }
        }

        public async Task<bool> SetPTZPreset(PTZClient ptzClient, string profileToken, string presetName, string presetToken)
        {
            try
            {
                var presetRequeset = new SetPresetRequest(profileToken, presetName, presetToken);
                var presetResponse = await ptzClient.SetPresetAsync(presetRequeset);

                if (presetResponse != null)
                {
                    _log?.Info($"Preset Token : {presetResponse.PresetToken}");
                }
                return true;
            }
            catch (Exception ex)
            {
                _log?.Error($"Raised Exception in {nameof(SetPTZPreset)} of {nameof(DeviceService)} : {ex.Message}");
                return false;
            }
        }

        public async Task<bool> DeletePTZPreset(PTZClient ptzClient, string profileToken, string presetToken)
        {
            try
            {
                await ptzClient.RemovePresetAsync(profileToken, presetToken);
                return true;
            }
            catch (Exception ex)
            {
                _log?.Error($"Raised Exception in {nameof(DeletePTZPreset)} of {nameof(DeviceService)} : {ex.Message}");
                return false;
            }
        }

        public async Task<bool> SetHomePreset(PTZClient ptzClient, string profileToken)
        {
            try
            {
                await ptzClient.SetHomePositionAsync(profileToken);
                return true;
            }
            catch (Exception ex)
            {
                _log?.Error($"Raised Exception in {nameof(SetHomePreset)} of {nameof(DeviceService)} : {ex.Message}");
                return false;
            }
        }

        public async Task<bool> GoHomePreset(PTZClient ptzClient, PTZSpeedModel pTZSpeed, string profileToken)
        {
            try
            {
                var ptzSpeed = GetPTZSpeedInstance(pTZSpeed);
                await ptzClient.GotoHomePositionAsync(profileToken, ptzSpeed);
                return true;
            }
            catch (Exception ex)
            {
                _log?.Error($"Raised Exception in {nameof(GoHomePreset)} of {nameof(DeviceService)} : {ex.Message}");
                return false;
            }
        }

        public async Task<bool> MovePTZ(PTZClient ptzClient, PTZSpeedModel pTZ_Velocity, string profileToken, CancellationToken token, string timeout = null)
        {
            try
            {
                var velocity = GetPTZSpeedInstance(pTZ_Velocity);
                var response = await ptzClient.ContinuousMoveAsync(profileToken, velocity, timeout);
                _log?.Info($"Response ContinuousMoveAsync : {response}");
                await Task.Delay(-1, token);
                return true;
            }
            catch (TaskCanceledException)
            {
                await StopPTZ(ptzClient, profileToken, true, true);
                return true;
            }
            catch (Exception ex)
            {
                _log?.Error($"Raised Exception in {nameof(MovePTZ)} of {nameof(DeviceService)} : {ex.Message}");
                return false;
            }
        }

        public async Task<bool> MovePTZ(PTZClient ptzClient, PTZSpeedModel pTZ_Velocity, string profileToken, string timeout = null)
        {
            try
            {
                var velocity = GetPTZSpeedInstance(pTZ_Velocity);
                var response = await ptzClient.ContinuousMoveAsync(profileToken, velocity, timeout);
                return true;
            }
            catch (Exception ex)
            {
                _log?.Error($"Raised Exception in {nameof(MovePTZ)} of {nameof(DeviceService)} : {ex.Message}");
                return false;
            }
        }

        public async Task<bool> StopPTZ(PTZClient ptzClient, string profileToken, bool panTilt, bool zoom)
        {
            try
            {
                await ptzClient.StopAsync(profileToken, panTilt, zoom);
                return true;
            }
            catch (Exception ex)
            {
                _log?.Error($"Raised Exception in {nameof(StopPTZ)} of {nameof(DeviceService)} : {ex.Message}");
                return false;
            }
        }

        public async Task<bool> MoveImaging(ImagingPortClient imagingPortClient, string vsourceToken, FocusMoveModel focusMove, CancellationToken token = default)
        {
            try
            {
                var focusMoveInstance = GetFocusMoveInstance(focusMove);
                await imagingPortClient.MoveAsync(vsourceToken, focusMoveInstance);
                await Task.Delay(-1, token);
                return true;
            }
            catch (TaskCanceledException)
            {
                await imagingPortClient.StopAsync(vsourceToken);
                return true;
            }
            catch (Exception ex)
            {
                _log?.Error($"Raised Exception in {nameof(MoveImaging)} of {nameof(DeviceService)} : {ex.Message}");
                return false;
            }
        }

        public async Task<bool> MoveImaging(ImagingPortClient imagingPortClient, string vsourceToken, FocusMoveModel focusMove)
        {
            try
            {
                var focusMoveInstance = GetFocusMoveInstance(focusMove);
                await imagingPortClient.MoveAsync(vsourceToken, focusMoveInstance);
                return true;
            }
            catch (Exception ex)
            {
                _log?.Error($"Raised Exception in {nameof(MoveImaging)} of {nameof(DeviceService)} : {ex.Message}");
                return false;
            }
        }


        public async Task<bool> StopImaging(ImagingPortClient imagingPortClient, string vsourceToken)
        {
            try
            {
                await imagingPortClient.StopAsync(vsourceToken);
                return true;
            }
            catch (Exception ex)
            {
                _log?.Error($"Raised Exception in {nameof(StopPTZ)} of {nameof(DeviceService)} : {ex.Message}");
                return false;
            }
        }

        private OnvifPtz.PTZSpeed GetPTZSpeedInstance(PTZSpeedModel pTZSpeed)
        {
            var ptzSpeed = new OnvifPtz.PTZSpeed();
            ptzSpeed.PanTilt = new OnvifPtz.Vector2D()
            {
                x = pTZSpeed.PanTilt.X,
                y = pTZSpeed.PanTilt.Y,
                space = pTZSpeed.PanTilt.Space,
            };
            ptzSpeed.Zoom = new OnvifPtz.Vector1D()
            {
                x = pTZSpeed.Zoom.X,
                space = pTZSpeed.Zoom.Space,
            };
            return ptzSpeed;
        }

        private OnvifImaging.FocusMove GetFocusMoveInstance(FocusMoveModel focusMoveModel)
        {
            ContinuousFocus continuousFocus = null;
            RelativeFocus relativeFocus = null;
            AbsoluteFocus absoluteFocus = null;

            if (focusMoveModel.ContinuousFocus != null)
            {
                continuousFocus = new ContinuousFocus()
                {
                    Speed = focusMoveModel.ContinuousFocus.Speed,
                };
            }

            if (focusMoveModel.RelativeFocus != null)
            {
                relativeFocus = new RelativeFocus()
                {
                    Distance = focusMoveModel.RelativeFocus.Distance,
                    Speed = focusMoveModel.RelativeFocus.Speed,
                    SpeedSpecified = focusMoveModel.RelativeFocus.SpeedSpecified,
                };
            }

            if (focusMoveModel.AbsoluteFocus != null)
            {
                absoluteFocus = new AbsoluteFocus()
                {
                    Position = focusMoveModel.AbsoluteFocus.Position,
                    Speed = focusMoveModel.AbsoluteFocus.Speed,
                    SpeedSpecified = focusMoveModel.AbsoluteFocus.SpeedSpecified,
                };
            }


            var focusMove = new OnvifImaging.FocusMove()
            {
                Absolute = absoluteFocus,
                Relative = relativeFocus,
                Continuous = continuousFocus,
            };

            return focusMove;
        }

       
        #endregion
        #region - IHanldes -
        #endregion
        #region - Properties -
        #endregion
        #region - Attributes -
        private ILogService _log;
        #endregion
    }
}
