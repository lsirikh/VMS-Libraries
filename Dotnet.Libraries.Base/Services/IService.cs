using System.Threading;
using System.Threading.Tasks;


namespace Dotnet.Libraries.Base
{
    public interface IService
    {   
        Task ExecuteAsync(CancellationToken token = default);
        Task StopAsync(CancellationToken token = default);
    }
}
