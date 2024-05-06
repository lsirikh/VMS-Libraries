using System.Windows;
using System.Windows.Media;

namespace Dotnet.Libraries.Utils
{
    /****************************************************************************
        Purpose      :                                                           
        Created By   : GHLee                                                
        Created On   : 4/25/2023 4:41:59 PM                                                    
        Department   : SW Team                                                   
        Company      : Sensorway Co., Ltd.                                       
        Email        : lsirikh@naver.com                                         
     ****************************************************************************/

    public static class VisualHelper
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
        /// <summary>
        /// VisualTreeHelper를 활용하여 주어진 부모 컨트롤(DependencyObject)로부터 특정 이름(childName)을 
        /// 가진 자식 컨트롤을 재귀적으로 찾는 메서드입니다. T는 찾고자 하는 컨트롤의 타입을 지정합니다. 
        /// 이 메서드는 일반적으로 다양한 WPF 컨트롤의 중첩된 구조 안에서 특정 이름을 가진 자식 컨트롤을 찾을 때 사용됩니다.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="parent"></param>
        /// <param name="childName"></param>
        /// <returns></returns>
        public static T FindChild<T>(DependencyObject parent, string childName) where T : FrameworkElement
        {
            if (parent == null) return null;

            T foundChild = null;
            int childrenCount = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < childrenCount; i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);
                if (child is T typedChild)
                {
                    if (typedChild.GetValue(FrameworkElement.NameProperty) as string == childName)
                    {
                        foundChild = typedChild;
                        break;
                    }
                }

                foundChild = FindChild<T>(child, childName);
                if (foundChild != null) break;
            }

            return foundChild;
        }

        /// <summary>
        /// VisualTreeHelper.GetParent 또는 LogicalTreeHelper.GetParent 메소드를 사용해 부모를 찾아갑니다. 
        /// 이 과정을 최상위 부모를 만날 때까지 반복합니다.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static T FindAncestorOrSelf<T>(DependencyObject obj) where T : DependencyObject
        {
            while (obj != null)
            {
                if (obj is T)
                {
                    return (T)obj;
                }

                obj = VisualTreeHelper.GetParent(obj) ?? LogicalTreeHelper.GetParent(obj);
            }

            return null;
        }
        #endregion
        #region - IHanldes -
        #endregion
        #region - Properties -
        #endregion
        #region - Attributes -
        #endregion
    }

    
}
