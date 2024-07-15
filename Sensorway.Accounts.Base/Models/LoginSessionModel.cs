using Newtonsoft.Json;
using System;

namespace Sensorway.Accounts.Base.Models
{
    /****************************************************************************
       Purpose      :                                                          
       Created By   : GHLee                                                
       Created On   : 5/27/2024 2:16:31 PM                                                    
       Department   : SW Team                                                   
       Company      : Sensorway Co., Ltd.                                       
       Email        : lsirikh@naver.com                                         
    ****************************************************************************/
    public class LoginSessionModel : LoginUserModel, ILoginSessionModel
    {
        #region - Ctors -
        public LoginSessionModel()
        {

        }

        public LoginSessionModel(ILoginSessionModel model) : base(model)
        {
            Token = model.Token;
            Mode = model.Mode;
            Expired = model.Expired;
        }

        public LoginSessionModel(int id, string username, string password, int clientId, string token, int mode, DateTime expired, DateTime created):
            base(id, username, password, clientId, created)
        {
            Token = token;
            Mode = mode;
            Expired = expired;
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
        [JsonProperty("token", Order = 5)]
        public string Token { get; set; }

        [JsonProperty("mode", Order = 6)]
        public int Mode { get; set; }

        [JsonProperty("expired", Order = 7)]
        public DateTime Expired { get; set; }
        #endregion
        #region - Attributes -
        #endregion
    }
}