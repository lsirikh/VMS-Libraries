namespace Sensorway.Framework.Models.Defines
{
    /****************************************************************************
        Purpose      :                                                           
        Created By   : GHLee                                                
        Created On   : 2/2/2024 1:44:15 PM                                                    
        Department   : SW Team                                                   
        Company      : Sensorway Co., Ltd.                                       
        Email        : lsirikh@naver.com                                         
     ****************************************************************************/

    public class SelectableItemModel : BaseModel, ISelectableItemModel
    {

        #region - Ctors -
        public SelectableItemModel()
        {

        }

        public SelectableItemModel(int id, string name, bool isSelected) : base(id)
        {
            Name = name;
            IsSelected = isSelected;
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
        public string Name { get; set; }
        public bool IsSelected { get; set; }
        #endregion
        #region - Attributes -
        #endregion
    }
}
