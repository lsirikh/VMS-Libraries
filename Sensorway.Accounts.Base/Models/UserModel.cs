using Newtonsoft.Json;
using Sensorway.Accounts.Base.Enums;
using System;
using System.Reflection;

namespace Sensorway.Accounts.Base.Models
{
    /****************************************************************************
       Purpose      :                                                          
       Created By   : GHLee                                                
       Created On   : 5/27/2024 11:42:47 AM                                                    
       Department   : SW Team                                                   
       Company      : Sensorway Co., Ltd.                                       
       Email        : lsirikh@naver.com                                         
    ****************************************************************************/
    public class UserModel : UserBaseModel, IUserModel
    {
        public UserModel()
        {
            
        }

        public UserModel(IUserModel model): base(model)
        {
            Username = model.Username;
            Password = model.Password;
            Name = model.Name;
            Level = model.Level;
            Used = model.Used;
            Created = model.Created;
        }

        [JsonProperty("username", Order = 2)]
        public string Username { get; set; }
        [JsonProperty("password", Order = 3)]
        public string Password { get; set; }
        [JsonProperty("name", Order = 4)]
        public string Name { get; set; }
        [JsonProperty("level", Order = 5)]
        public EnumUserLevel Level { get; set; } = EnumUserLevel.USER;
        [JsonProperty("used", Order = 6)]
        public bool Used { get; set; }
        
    }

}