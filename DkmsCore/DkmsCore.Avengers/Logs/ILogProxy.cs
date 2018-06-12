﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DkmsCore.Avengers.Logs
{
    public interface ILogProxy
    {
        Task Warn(string message);
        Task Info(string message);
        Task Exception(Exception exception);
    }
}
