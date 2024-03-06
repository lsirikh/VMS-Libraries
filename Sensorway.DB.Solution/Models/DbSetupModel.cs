namespace Sensorway.DB.Solution.Models
{
    /****************************************************************************
        Purpose      :                                                           
        Created By   : GHLee                                                
        Created On   : 2/5/2024 1:37:03 PM                                                    
        Department   : SW Team                                                   
        Company      : Sensorway Co., Ltd.                                       
        Email        : lsirikh@naver.com                                         
     ****************************************************************************/

    public class DbSetupModel
    {
        #region - Ctors -
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
        public string PathDatabase => Properties.Settings.Default.PathDatabase;
        public string NameDatabase => Properties.Settings.Default.NameDatabase;
        public int Version => Properties.Settings.Default.Version;
        #endregion
        #region - Attributes -
        #endregion
    }
}
