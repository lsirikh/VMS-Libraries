namespace DotNet.ResourceMonitor.Models
{
    /****************************************************************************
        Purpose      :                                                           
        Created By   : GHLee                                                
        Created On   : 2/21/2024 1:43:56 PM                                                    
        Department   : SW Team                                                   
        Company      : Sensorway Co., Ltd.                                       
        Email        : lsirikh@naver.com                                         
     ****************************************************************************/

    public class GPUModel
    {

        public string Name { get; set; }
        public int Usage { get; set; }
        public int CurrentTemp { get; set; }

    }
}
