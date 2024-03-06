using System.Diagnostics;

namespace DotNet.ResourceMonitor.Models
{
    /****************************************************************************
        Purpose      :                                                           
        Created By   : GHLee                                                
        Created On   : 2/20/2024 1:44:16 PM                                                    
        Department   : SW Team                                                   
        Company      : Sensorway Co., Ltd.                                       
        Email        : lsirikh@naver.com                                         
     ****************************************************************************/

    public class NetworkPerformanceModel
    {
        public string Description { get; set; }
        public PerformanceCounter NetworkBandwidth { get; set; }
        public PerformanceCounter NetworkSendCounter { get; set; }
        public PerformanceCounter NetworkReceiveCounter { get; set; }
    }
}
