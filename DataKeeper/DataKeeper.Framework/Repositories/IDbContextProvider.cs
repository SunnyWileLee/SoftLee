﻿using DataKeeper.Infrustructure;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataKeeper.Framework.Repositories
{
    public interface IDbContextProvider : IScoper
    {
        DbContext Provide();
    }
}
