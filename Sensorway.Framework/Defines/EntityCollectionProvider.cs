using System.Collections;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Data;
using Dotnet.Libraries.Base.DataProviders;

namespace Sensorway.Framework.Defines
{
    /****************************************************************************
        Purpose      :                                                           
        Created By   : GHLee                                                
        Created On   : 2/6/2024 3:36:46 PM                                                    
        Department   : SW Team                                                   
        Company      : Sensorway Co., Ltd.                                       
        Email        : lsirikh@naver.com                                         
     ****************************************************************************/

    [DebuggerDisplay("Count = {CollectionEntity.Count}")]
    public abstract class EntityCollectionProvider<T> : ICollector<T>
    {

        #region - Ctors -
        public EntityCollectionProvider()
        {
            CollectionEntity = new ObservableCollection<T>();
            _locker = new object();
            //해당 메소드의 기능
            BindingOperations.EnableCollectionSynchronization(CollectionEntity, _locker);
        }

        public EntityCollectionProvider(IEnumerable<T> collection)
        {
            CollectionEntity = new ObservableCollection<T>(collection);
            _locker = new object();
            BindingOperations.EnableCollectionSynchronization(CollectionEntity, _locker);
        }
        #endregion
        #region - Implementation of Interface -
        #endregion
        #region - Overrides -
        #endregion
        #region - Binding Methods -
        #endregion
        #region - Processes -
        public virtual void Add(T item)
        {
            try
            {
                lock (_locker)
                {
                    CollectionEntity.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Provider Exception : {ex.Message}");
            }

        }

        public virtual void Remove(T item)
        {
            try
            {
                var result = false;
                lock (_locker)
                {
                    result = CollectionEntity.Remove(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Provider Exception : {ex.Message}");
            }
        }

        public virtual void Clear()
        {
            try
            {
                lock (_locker)
                {
                    CollectionEntity.Clear();
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Provider Exception : {ex.Message}");
            }
        }


        /// Question!! SetItem을 활용하려면 현재 구조를 어떻게 바꾸면 좋을까....
        public virtual void MoveItem(int oldIndex, int newIndex)
        {
            try
            {
                lock (_locker)
                {
                    CollectionEntity.Move(oldIndex, newIndex);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Provider Exception : {ex.Message}");
            }
        }


        public IEnumerator<T> GetEnumerator()
        {
            return CollectionEntity.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return CollectionEntity.GetEnumerator();
        }

        public int Count => CollectionEntity.Count;
        #endregion
        #region - IHanldes -
        #endregion
        #region - Properties -
        public ObservableCollection<T> CollectionEntity { get; set; }
        #endregion
        #region - Attributes -
        protected readonly object _locker;
        #endregion
    }
}
