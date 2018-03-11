﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataKeeper.Framework.Repositories
{
    public interface IPropertyRepositoryProvider
    {
        IPropertyRepository Provide();
        IPropertyRepository Provide(Func<IPropertyRepository, bool> selector);
    }
}