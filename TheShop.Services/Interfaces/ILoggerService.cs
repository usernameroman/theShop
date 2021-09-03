using System;
using System.Collections.Generic;
using System.Text;

namespace TheShop.Services.Interfaces
{
    public interface ILoggerService
    {
        public void Info(string message);

        public void Error(string message);

        public void Debug(string message);
    }
}
