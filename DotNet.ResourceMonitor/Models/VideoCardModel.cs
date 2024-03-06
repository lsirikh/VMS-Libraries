using System;
using System.Management;

namespace DotNet.ResourceMonitor.Models
{
    /****************************************************************************
        Purpose      :                                                           
        Created By   : GHLee                                                
        Created On   : 2/17/2024 7:55:44 AM                                                    
        Department   : SW Team                                                   
        Company      : Sensorway Co., Ltd.                                       
        Email        : lsirikh@naver.com                                         
     ****************************************************************************/

    public class VideoCardModel
    {
        public ushort? AcceleratorCapabilities { get; set; }
        public string AdapterCompatibility { get; set; }
        public string AdapterDACType { get; set; }
        public uint AdapterRAM { get; set; }
        public ushort Availability { get; set; }
        public string CapabilityDescriptions { get; set; }
        public string Caption { get; set; }
        public uint? ColorTableEntries { get; set; }
        public uint ConfigManagerErrorCode { get; set; }
        public bool ConfigManagerUserConfig { get; set; }
        public string CreationClassName { get; set; }
        public uint CurrentBitsPerPixel { get; set; }
        public uint CurrentHorizontalResolution { get; set; }
        public ulong CurrentNumberOfColors { get; set; }
        public uint? CurrentNumberOfColumns { get; set; }
        public uint? CurrentNumberOfRows { get; set; }
        public uint CurrentRefreshRate { get; set; }
        public ushort CurrentScanMode { get; set; }
        public uint CurrentVerticalResolution { get; set; }
        public string Description { get; set; }
        public string DeviceID { get; set; }
        public uint? DeviceSpecificPens { get; set; }
        public uint? DitherType { get; set; }
        public DateTime? DriverDate { get; set; }
        public string DriverVersion { get; set; }
        public bool? ErrorCleared { get; set; }
        public string ErrorDescription { get; set; }
        public uint? ICMIntent { get; set; }
        public uint? ICMMethod { get; set; }
        public string InfFilename { get; set; }
        public string InfSection { get; set; }
        public DateTime? InstallDate { get; set; }
        public string InstalledDisplayDrivers { get; set; }
        public uint? LastErrorCode { get; set; }
        public uint? MaxMemorySupported { get; set; }
        public uint? MaxNumberControlled { get; set; }
        public uint MaxRefreshRate { get; set; }
        public uint MinRefreshRate { get; set; }
        public bool Monochrome { get; set; }
        public string Name { get; set; }
        public ushort? NumberOfColorPlanes { get; set; }
        public uint? NumberOfVideoPages { get; set; }
        public string PNPDeviceID { get; set; }
        public ushort[] PowerManagementCapabilities { get; set; }
        public bool PowerManagementSupported { get; set; }
        public ushort? ProtocolSupported { get; set; }
        public uint? ReservedSystemPaletteEntries { get; set; }
        public uint? SpecificationVersion { get; set; }
        public string Status { get; set; }
        public ushort? StatusInfo { get; set; }
        public string SystemCreationClassName { get; set; }
        public string SystemName { get; set; }
        public uint? SystemPaletteEntries { get; set; }
        public DateTime? TimeOfLastReset { get; set; }
        public ushort VideoArchitecture { get; set; }
        public ushort VideoMemoryType { get; set; }
        public ushort? VideoMode { get; set; }
        public string VideoModeDescription { get; set; }
        public string VideoProcessor { get; set; }

    }

}
