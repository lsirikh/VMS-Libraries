using Newtonsoft.Json;
using System;
using System.Reflection;

namespace Sensorway.Accounts.Base.Models
{
    /****************************************************************************
       Purpose      :                                                          
       Created By   : GHLee                                                
       Created On   : 5/27/2024 1:13:08 PM                                                    
       Department   : SW Team                                                   
       Company      : Sensorway Co., Ltd.                                       
       Email        : lsirikh@naver.com                                         
    ****************************************************************************/
    public class LoginUserModel : UserBaseModel, ILoginUserModel
    {
        public LoginUserModel()
        {

        }

        public LoginUserModel(ILoginUserModel model) : base(model)
        {
            Username = model.Username;
            Password = model.Password;
            ClientId = model.ClientId;
        }

        public LoginUserModel(int id, string username, string password, int clientId, DateTime created): base(id, created)
        {
            Username = username;
            Password = password;
            ClientId = clientId;
        }


        [JsonProperty("username", Order = 2)]
        public string Username { get; set; }
        
        [JsonProperty("password", Order = 3)]
        public string Password { get; set; }

        [JsonProperty("client_id", Order = 4)]
        public int ClientId { get; set; }
       
    }
}