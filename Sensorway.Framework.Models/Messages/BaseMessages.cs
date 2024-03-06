namespace Sensorway.Framework.Models.Messages
{
    /****************************************************************************
        Purpose      :                                                           
        Created By   : GHLee                                                
        Created On   : 2/2/2024 11:28:54 AM                                                    
        Department   : SW Team                                                   
        Company      : Sensorway Co., Ltd.                                       
        Email        : lsirikh@naver.com                                         
     ****************************************************************************/

    public class CloseAllMessageModel
    {
    }

    public class CloseDialogMessageModel
    {
    }

    public class ClosePanelMessageModel
    {
    }

    public class ClosePopupMessageModel
    {
    }

    public class ExitProgramMessageModel : IMessageModel
    {
    }

    public class OpenConfirmPopupMessageModel
        : CommonMessageModel
    {
    }

    public class OpenInfoPopupMessageModel
        : CommonMessageModel
    {
    }

    public class OpenProgressPopupMessageModel
        : IMessageModel
    {
    }

    public class StatusMessageModel
    {
        public StatusMessageModel()
        {
        }

        public StatusMessageModel(string log)
        {
            Log = log;
        }

        public string Log { get; set; }
    }
}
