using Newtonsoft.Json;
using System;

namespace Sensorway.Accounts.Base.Models
{
    /****************************************************************************
       Purpose      :                                                          
       Created By   : GHLee                                                
       Created On   : 5/27/2024 11:40:38 AM                                                    
       Department   : SW Team                                                   
       Company      : Sensorway Co., Ltd.                                       
       Email        : lsirikh@naver.com                                         
    ****************************************************************************/
    public abstract class UserBaseModel : IUserBaseModel
    {
        public UserBaseModel()
        {
        }

        protected UserBaseModel(IUserBaseModel model)
        {
            Id = model.Id;
            Created = model.Created;
        }

        public UserBaseModel(int id, DateTime created)
        {
            Id = id;
            Created = created;
        }

        [JsonProperty("id", Order = 1)]
        public int Id { get; set; }

        [JsonProperty("created", Order = 9)]
        public DateTime Created { get; set; }
    }
}