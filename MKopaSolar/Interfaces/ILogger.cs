using System;

namespace MKopaSolar.Interfaces
{
    public interface ILogger
    {
        void LogError(Exception ex, string message, params object[] args);
        void LogError(Exception ex, string message);
        void LogError(string message);
        void LogWarning(Exception ex, string message, params object[] args);
        void LogWarning(Exception ex, string message);
        void LogWarning(string message);
    }
}
