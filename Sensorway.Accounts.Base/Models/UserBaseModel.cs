using Newtonsoft.Json;
using Sensorway.Framework.Models.Defines;
using System;
using System.Reflection;

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
    public abstract class UserBaseModel : BaseModel, IUserBaseModel
    {
        public UserBaseModel()
        {
        }

        protected UserBaseModel(IUserBaseModel model) : base(model.Id)
        {
            Created = model.Created;
        }

        public UserBaseModel(int id, DateTime created) : base(id)
        {
            Created = created;
        }

        [JsonProperty("created", Order = 9)]
        public DateTime Created { get; set; }
    }
}