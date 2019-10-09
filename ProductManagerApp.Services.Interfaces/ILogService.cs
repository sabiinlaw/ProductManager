using ProductManagerApp.Domain.Core;
using System.Collections.Generic;

namespace ProductManagerApp.Services.Interfaces
{
    public interface ILogService
    {
        void SaveLog(Log log);
        List<Log> GetAll();
    }
}
