using DotNet.ResourceMonitor.Models;
using System;

namespace DotNet.ResourceMonitor.Utils
{
    /****************************************************************************
        Purpose      :                                                           
        Created By   : GHLee                                                
        Created On   : 2/17/2024 9:16:23 AM                                                    
        Department   : SW Team                                                   
        Company      : Sensorway Co., Ltd.                                       
        Email        : lsirikh@naver.com                                         
     ****************************************************************************/

    public static class Factory
    {

        public static T Build<T>() where T : class, new()
        {
            var instance = (T)Activator.CreateInstance(typeof(T), new object[] { });
            return instance;
        }
    }
}
