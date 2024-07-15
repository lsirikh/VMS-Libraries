using System;
using System.Net;

namespace Sensorway.Api.Server.Helpers
{
    /****************************************************************************
       Purpose      :                                                          
       Created By   : GHLee                                                
       Created On   : 5/30/2024 6:11:53 PM                                                    
       Department   : SW Team                                                   
       Company      : Sensorway Co., Ltd.                                       
       Email        : lsirikh@naver.com                                         
    ****************************************************************************/
    public class ReceiveEventArgs : EventArgs
    {
        #region - Ctors -
        public ReceiveEventArgs(HttpListenerContext context)
        {
            Context = context;
        }
        #endregion
        #region - Implementation of Interface -
        #endregion
        #region - Overrides -
        #endregion
        #region - Binding Methods -
        #endregion
        #region - Processes -
        #endregion
        #region - IHanldes -
        #endregion
        #region - Properties -
        public HttpListenerContext Context { get; set; }
        #endregion
        #region - Attributes -
        #endregion
    }
}