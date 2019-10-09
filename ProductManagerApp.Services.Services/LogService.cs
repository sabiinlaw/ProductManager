using ProductManagerApp.Domain.Core;
using ProductManagerApp.Domain.Interfaces;
using ProductManagerApp.Services.Interfaces;
using System.Collections.Generic;

namespace ProductManagerApp.Services.Services
{
    public class LogService : ILogService
    {
        IUnitOfWork<Log> _unitOfWork;
        public LogService(IUnitOfWork<Log> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public List<Log> GetAll()
        {
            return _unitOfWork.GetAll();
        }

        public void SaveLog(Log log)
        {
            _unitOfWork.Create(log);
        }
    }
}
