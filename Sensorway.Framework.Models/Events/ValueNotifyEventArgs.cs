using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensorway.Framework.Models.Events
{
    public class ValueNotifyEventArgs<T> : EventArgs
    {
        public T Value { get; set; }
    }
}
