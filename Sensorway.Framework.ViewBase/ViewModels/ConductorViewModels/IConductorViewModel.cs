
using Sensorway.Framework.Models.Messages;
using System.Threading;
using System.Threading.Tasks;

namespace Sensorway.Framework.ViewBase.ViewModels.ConductorViewModels
{
    public interface IConductorViewModel : IBasePanelViewModel
    {
        bool IsVisible { get; set; }

        //Task HandleAsync(CloseAllMessageModel message, CancellationToken cancellationToken);
    }
}