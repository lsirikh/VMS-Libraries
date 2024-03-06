﻿namespace Dotnet.Libraries.Base
{
    public interface ILogService
    {
        void Error(string msg, bool debug = true);
        void Info(string msg, bool debug = true);
        void Warning(string msg, bool debug = true);
    }
}