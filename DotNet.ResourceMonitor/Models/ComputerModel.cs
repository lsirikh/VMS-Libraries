using System;
using System.Diagnostics;
using System.Management;

namespace DotNet.ResourceMonitor.Models
{
    /****************************************************************************
        Purpose      :                                                           
        Created By   : GHLee                                                
        Created On   : 2/17/2024 8:06:49 AM                                                    
        Department   : SW Team                                                   
        Company      : Sensorway Co., Ltd.                                       
        Email        : lsirikh@naver.com                                         
     ****************************************************************************/


    public class ComputerModel
    {
        //    public PropertyData AdminPasswordStatus { get; set; }
        //    public PropertyData AutomaticManagedPagefile { get; set; }
        //    public PropertyData AutomaticResetBootOption { get; set; }
        //    public PropertyData AutomaticResetCapability { get; set; }
        //    public PropertyData BootOptionOnLimit { get; set; }
        //    public PropertyData BootOptionOnWatchDog { get; set; }
        //    public PropertyData BootROMSupported { get; set; }
        //    public PropertyData BootStatus { get; set; }
        //    public PropertyData BootupState { get; set; }
        //    public PropertyData Caption { get; set; }
        //    public PropertyData ChassisBootupState { get; set; }
        //    public PropertyData ChassisSKUNumber { get; set; }
        //    public PropertyData CreationClassName { get; set; }
        //    public PropertyData CurrentTimeZone { get; set; }
        //    public PropertyData DaylightInEffect { get; set; }
        //    public PropertyData Description { get; set; }
        //    public PropertyData DNSHostName { get; set; }
        //    public PropertyData Domain { get; set; }
        //    public PropertyData DomainRole { get; set; }
        //    public PropertyData EnableDaylightSavingsTime { get; set; }
        //    public PropertyData FrontPanelResetStatus { get; set; }
        //    public PropertyData HypervisorPresent { get; set; }
        //    public PropertyData InfraredSupported { get; set; }
        //    public PropertyData InitialLoadInfo { get; set; }
        //    public PropertyData InstallDate { get; set; }
        //    public PropertyData KeyboardPasswordStatus { get; set; }
        //    public PropertyData LastLoadInfo { get; set; }
        //    public PropertyData Manufacturer { get; set; }
        //    public PropertyData Model { get; set; }
        //    public PropertyData Name { get; set; }
        //    public PropertyData NameFormat { get; set; }
        //    public PropertyData NetworkServerModeEnabled { get; set; }
        //    public PropertyData NumberOfLogicalProcessors { get; set; }
        //    public PropertyData NumberOfProcessors { get; set; }
        //    public PropertyData OEMLogoBitmap { get; set; }
        //    public PropertyData OEMStringArray { get; set; }
        //    public PropertyData PartOfDomain { get; set; }
        //    public PropertyData PauseAfterReset { get; set; }
        //    public PropertyData PCSystemType { get; set; }
        //    public PropertyData PCSystemTypeEx { get; set; }
        //    public PropertyData PowerManagementCapabilities { get; set; }
        //    public PropertyData PowerManagementSupported { get; set; }
        //    public PropertyData PowerOnPasswordStatus { get; set; }
        //    public PropertyData PowerState { get; set; }
        //    public PropertyData PowerSupplyState { get; set; }
        //    public PropertyData PrimaryOwnerContact { get; set; }
        //    public PropertyData PrimaryOwnerName { get; set; }
        //    public PropertyData ResetCapability { get; set; }
        //    public PropertyData ResetCount { get; set; }
        //    public PropertyData ResetLimit { get; set; }
        //    public PropertyData Roles { get; set; }
        //    public PropertyData Status { get; set; }
        //    public PropertyData SupportContactDescription { get; set; }
        //    public PropertyData SystemFamily { get; set; }
        //    public PropertyData SystemSKUNumber { get; set; }
        //    public PropertyData SystemStartupDelay { get; set; }
        //    public PropertyData SystemStartupOptions { get; set; }
        //    public PropertyData SystemStartupSetting { get; set; }
        //    public PropertyData SystemType { get; set; }
        //    public PropertyData ThermalState { get; set; }
        //    public PropertyData TotalPhysicalMemory { get; set; }
        //    public PropertyData UserName { get; set; }
        //    public PropertyData WakeUpType { get; set; }
        //    public PropertyData Workgroup { get; set; }

        public ushort AdminPasswordStatus { get; set; }
        public bool AutomaticManagedPagefile { get; set; }
        public bool AutomaticResetBootOption { get; set; }
        public bool AutomaticResetCapability { get; set; }
        public ushort? BootOptionOnLimit { get; set; }
        public ushort? BootOptionOnWatchDog { get; set; }
        public bool BootROMSupported { get; set; }
        public ushort[] BootStatus { get; set; }
        public string BootupState { get; set; }
        public string Caption { get; set; }
        public ushort ChassisBootupState { get; set; }
        public string ChassisSKUNumber { get; set; }
        public string CreationClassName { get; set; }
        public short CurrentTimeZone { get; set; }
        public bool? DaylightInEffect { get; set; }
        public string Description { get; set; }
        public string DNSHostName { get; set; }
        public string Domain { get; set; }
        public ushort DomainRole { get; set; }
        public bool EnableDaylightSavingsTime { get; set; }
        public ushort FrontPanelResetStatus { get; set; }
        public bool HypervisorPresent { get; set; }
        public bool InfraredSupported { get; set; }
        public string InitialLoadInfo { get; set; }
        public DateTime? InstallDate { get; set; }
        public ushort KeyboardPasswordStatus { get; set; }
        public string LastLoadInfo { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string Name { get; set; }
        public string NameFormat { get; set; }
        public bool NetworkServerModeEnabled { get; set; }
        public uint NumberOfLogicalProcessors { get; set; }
        public uint NumberOfProcessors { get; set; }
        public byte[] OEMLogoBitmap { get; set; }
        public string[] OEMStringArray { get; set; }
        public bool PartOfDomain { get; set; }
        public long PauseAfterReset { get; set; }
        public ushort PCSystemType { get; set; }
        public ushort PCSystemTypeEx { get; set; }
        public ushort[] PowerManagementCapabilities { get; set; }
        public bool PowerManagementSupported { get; set; }
        public ushort PowerOnPasswordStatus { get; set; }
        public ushort PowerState { get; set; }
        public ushort PowerSupplyState { get; set; }
        public string PrimaryOwnerContact { get; set; }
        public string PrimaryOwnerName { get; set; }
        public ushort ResetCapability { get; set; }
        public short ResetCount { get; set; }
        public short ResetLimit { get; set; }
        public string[] Roles { get; set; }
        public string Status { get; set; }
        public string SupportContactDescription { get; set; }
        public string SystemFamily { get; set; }
        public string SystemSKUNumber { get; set; }
        public ushort SystemStartupDelay { get; set; }
        public string SystemStartupOptions { get; set; }
        public byte SystemStartupSetting { get; set; }
        public string SystemType { get; set; }
        public ushort ThermalState { get; set; }
        public ulong TotalPhysicalMemory { get; set; }
        public string UserName { get; set; }
        public ushort WakeUpType { get; set; }
        public string Workgroup { get; set; }
    }

}
