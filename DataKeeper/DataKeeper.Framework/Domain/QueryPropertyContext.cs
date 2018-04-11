using DataKeeper.Framework.Entities;
using DataKeeper.Framework.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataKeeper.Framework.Domain
{
    public class QueryPropertyContext<TProperty> : AccessDbContext
        where TProperty : PropertyEntity
    {
       
    }
}
