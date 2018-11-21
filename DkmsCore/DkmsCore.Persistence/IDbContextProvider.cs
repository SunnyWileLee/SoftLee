using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DkmsCore.Persistence
{
    public interface IDbContextProvider
    {
        DbContext Provide();
    }
}
