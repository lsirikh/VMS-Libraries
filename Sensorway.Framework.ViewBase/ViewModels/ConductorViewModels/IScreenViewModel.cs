using Dotnet.Libraries.Enums;
using Sensorway.Framework.Models.Messages;
using System.Threading;
using System.Threading.Tasks;

namespace Sensorway.Framework.ViewBase.ViewModels.ConductorViewModels
{
    public interface IScreenViewModel
    {
        CategoryEnum ClassCategory { get; set; }
        string ClassContent { get; set; }
        int ClassId { get; set; }
        string ClassName { get; set; }

        Task HandleAsync(CloseAllMessageModel message, CancellationToken cancellationToken);
    }
}