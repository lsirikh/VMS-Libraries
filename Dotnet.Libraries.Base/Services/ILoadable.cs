using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Dotnet.Libraries.Base
{
    public interface ILoadable
    {
        Task<bool> Initialize(CancellationToken token = default);
        void Uninitialize();
    }
}
