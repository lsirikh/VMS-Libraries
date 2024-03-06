namespace Sensorway.VMS.Messages.Enums
{
    /****************************************************************************
        Purpose      :                                                           
        Created By   : GHLee                                                
        Created On   : 2/6/2024 10:14:27 AM                                                    
        Department   : SW Team                                                   
        Company      : Sensorway Co., Ltd.                                       
        Email        : lsirikh@naver.com                                         
     ****************************************************************************/

    public enum EnumCommand
    {
        NONE,

        /// <summary>
        /// Camera Information Request & Response
        /// </summary>
        REQUEST_REGISTER_CAMERA_DEVICE,
        RESPONSE_REGISTER_CAMERA_DEVICE,

        REQUEST_UNREGISTER_CAMERA_DEVICE,
        RESPONSE_UNREGISTER_CAMERA_DEVICE,

        REQUEST_EDITE_CAMERA_DEVICE,
        RESPONSE_EDITE_CAMERA_DEVICE,

        REQUEST_CAMERA_LIST,
        RESPONSE_CAMERA_LIST,

        /// <summary>
        /// Camera Preset Control Request & Response
        /// </summary>
        REQUEST_PRESET_LIST,
        RESPONSE_PRESET_LIST,

        REQUEST_SET_PRESET,
        RESPONSE_SET_PRESET,

        REQUEST_DELETE_PRESET,
        RESPONSE_DELETE_PRESET,

        REQUEST_MOVE_PRESET,
        RESPONSE_MOVE_PRESET,

        /// <summary>
        /// Dummy File List Request & Response
        /// </summary>
        REQUEST_DUMMY_LIST,
        RESPONSE_DUMMY_LIST,

        /// <summary>
        /// Zone Related Information Request & Response
        /// </summary>
        REQUEST_ZONE_LIST,
        RESPONSE_ZONE_LIST,

        REQUEST_SET_ZONE,
        RESPONSE_SET_ZONE,

        REQUEST_DELETE_ZONE,
        RESPONSE_DELETE_ZONE,


        /// <summary>
        /// PTZ Control Request & Response
        /// </summary>
        REQUEST_PTZ_CONTROL_TOP_LEFT,
        RESPONSE_PTZ_CONTROL_TOP_LEFT,
        REQUEST_PTZ_CONTROL_TOP_CENTER,
        RESPONSE_PTZ_CONTROL_TOP_CENTER,
        REQUEST_PTZ_CONTROL_TOP_RIGHT,
        RESPONSE_PTZ_CONTROL_TOP_RIGHT,

        REQUEST_PTZ_CONTROL_LEFT,
        RESPONSE_PTZ_CONTROL_LEFT,
        REQUEST_PTZ_CONTROL_RIGHT,
        RESPONSE_PTZ_CONTROL_RIGHT,

        REQUEST_PTZ_CONTROL_BOTTOM_LEFT,
        RESPONSE_PTZ_CONTROL_BOTTOM_LEFT, 
        REQUEST_PTZ_CONTROL_BOTTOM_CENTER,
        RESPONSE_PTZ_CONTROL_BOTTOM_CENTER, 
        REQUEST_PTZ_CONTROL_BOTTOM_RIGHT,
        RESPONSE_PTZ_CONTROL_BOTTOM_RIGHT,

        REQUEST_PTZ_CONTROL_ZOOML_IN,
        RESPONSE_PTZ_CONTROL_ZOOML_IN,
        REQUEST_PTZ_CONTROL_ZOOML_OUT,
        RESPONSE_PTZ_CONTROL_ZOOML_OUT,

        REQUEST_PTZ_CONTROL_STOP,
        RESPONSE_PTZ_CONTROL_STOP,

        REQUEST_FOCUS_IN_CONTROL,
        REQUEST_FOCUS_OUT_CONTROL,
        REQUEST_FOCUS_STOP_CONTROL,

        RESPONSE_FOCUS_IN_CONTROL,
        RESPONSE_FOCUS_OUT_CONTROL,
        RESPONSE_FOCUS_STOP_CONTROL,


    }
}
