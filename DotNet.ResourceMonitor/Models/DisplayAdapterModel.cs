namespace DotNet.ResourceMonitor.Models
{
    /****************************************************************************
        Purpose      :                                                           
        Created By   : GHLee                                                
        Created On   : 2/20/2024 9:48:45 AM                                                    
        Department   : SW Team                                                   
        Company      : Sensorway Co., Ltd.                                       
        Email        : lsirikh@naver.com                                         
     ****************************************************************************/

    public class DisplayAdapterModel
    {
        public uint BitsPerPel { get; set; }
        public string Caption { get; set; }
        public string Description { get; set; }
        public string DeviceName { get; set; }
        public uint DisplayFlags { get; set; }
        public uint DisplayFrequency { get; set; }
        public uint? DitherType { get; set; } // 값이 없을 수 있으므로 nullable로 선언
        public string DriverVersion { get; set; }
        public uint? ICMIntent { get; set; } // 값이 없을 수 있으므로 nullable로 선언
        public uint? ICMMethod { get; set; } // 값이 없을 수 있으므로 nullable로 선언
        public uint LogPixels { get; set; }
        public uint PelsHeight { get; set; }
        public uint PelsWidth { get; set; }
        public string SettingID { get; set; }
        public uint SpecificationVersion { get; set; }
    }
}
