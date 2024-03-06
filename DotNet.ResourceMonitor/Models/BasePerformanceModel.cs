using System.Collections.Generic;
using System.Diagnostics;

namespace DotNet.ResourceMonitor.Models
{
    /****************************************************************************
        Purpose      :                                                           
        Created By   : GHLee                                                
        Created On   : 2/17/2024 8:24:14 AM                                                    
        Department   : SW Team                                                   
        Company      : Sensorway Co., Ltd.                                       
        Email        : lsirikh@naver.com                                         
     ****************************************************************************/

    public class BasePerformanceModel
    {
        /// <summary>
        /// CPU 사용량을 확인하기 위한 Counter
        /// </summary>
        public PerformanceCounter CpuCounter { get; set; }
        /// <summary>
        /// Ram의 사용량을 확인하기 위한 Counter
        /// </summary>
        public PerformanceCounter RamCounter { get; set; }
        /// <summary>
        /// Non-Graphic Card(Board based) GPU의 사용량을 확인하기 위한 Counter
        /// </summary>
        public List<PerformanceCounter> GpuCounter { get; set; }
        /// <summary>
        /// Network 사용량을 확인하기 위한 Counter
        /// </summary>
        public List<NetworkPerformanceModel> NetworkCatergories { get; set; } = new List<NetworkPerformanceModel>();
        
    }
}
