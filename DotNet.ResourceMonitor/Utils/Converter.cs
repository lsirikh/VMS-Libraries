using System;

namespace DotNet.ResourceMonitor.Utils
{
    /****************************************************************************
        Purpose      :                                                           
        Created By   : GHLee                                                
        Created On   : 2/18/2024 10:59:58 AM                                                    
        Department   : SW Team                                                   
        Company      : Sensorway Co., Ltd.                                       
        Email        : lsirikh@naver.com                                         
     ****************************************************************************/

    public static class Converter
    {
        /// <summary>
        /// WMI 날짜/시간 형식의 문자열을 .NET의 DateTime으로 변환합니다.
        /// WMI 형식은 일반적으로 'yyyymmddHHMMSS.ffffff±UUU' 형식을 따릅니다.
        /// 이 메서드는 문자열을 분석하여 년, 월, 일, 시, 분, 초, 밀리초를 추출하고,
        /// UTC 시차를 적용하여 DateTime 객체로 변환합니다.
        /// </summary>
        /// <param name="dmtfDate">WMI 날짜/시간 형식의 문자열</param>
        /// <returns>변환된 DateTime 객체 또는 변환에 실패할 경우 null</returns>
        public static DateTime? ConvertToDateTime(string dmtfDate)
        {
            if (dmtfDate == null || dmtfDate.Length == 0 || dmtfDate.Substring(0, 4) == "0000")
            {
                return null;
            }

            try
            {
                int year = int.Parse(dmtfDate.Substring(0, 4));
                int month = int.Parse(dmtfDate.Substring(4, 2));
                int day = int.Parse(dmtfDate.Substring(6, 2));
                int hour = int.Parse(dmtfDate.Substring(8, 2));
                int minute = int.Parse(dmtfDate.Substring(10, 2));
                int second = int.Parse(dmtfDate.Substring(12, 2));
                int millisec = int.Parse(dmtfDate.Substring(15, 3));

                string timeZoneStr = dmtfDate.Substring(21, 3);
                TimeSpan utcOffset = new TimeSpan(0, int.Parse(timeZoneStr), 0);

                DateTime date = new DateTime(year, month, day, hour, minute, second, millisec);
                date = DateTime.SpecifyKind(date, DateTimeKind.Utc).Subtract(utcOffset);

                return date;
            }
            catch
            {
                return null;
            }
        }
    }
}
