using Dotnet.Libraries.Base;
using Sensorway.Framework.Enums;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Sensorway.Framework.Services
{
    /****************************************************************************
       Purpose      :                                                          
       Created By   : GHLee                                                
       Created On   : 1/9/2025 9:46:09 AM                                                    
       Department   : SW Team                                                   
       Company      : Sensorway Co., Ltd.                                       
       Email        : lsirikh@naver.com                                         
    ****************************************************************************/
    public abstract class TaskTimerService : IService
    {
        
        #region - Ctors -
        protected TaskTimerService(ILogService log)
        {
            _log = log; 
        }
        #endregion
        #region - Implementation of Interface -
        public virtual Task ExecuteAsync(CancellationToken token = default)
        {
            Initializer();
            return Task.CompletedTask;
        }

        public virtual Task StopAsync(CancellationToken token = default)
        {
            Dispose();
            return Task.CompletedTask;
        }
        #endregion
        #region - Overrides -

        #endregion
        #region - Binding Methods -
        #endregion
        #region - Processes -
        protected void Initializer()
        {
            state = EnumTimerStatus.STOP;
            _timer = new Timer(Callback, state, 0, INTERVAL_MS);
            state = EnumTimerStatus.RUN;
        }

        protected abstract void Callback(object state);

        protected void Dispose()
        {
            _timer.Dispose();
        }
        #endregion
        #region - IHanldes -
        #endregion
        #region - Properties -
        #endregion
        #region - Attributes -
        private ILogService _log;
        private Timer _timer;
        protected EnumTimerStatus state;
        private const int INTERVAL_MS = 1000*10;
        #endregion

    }
}