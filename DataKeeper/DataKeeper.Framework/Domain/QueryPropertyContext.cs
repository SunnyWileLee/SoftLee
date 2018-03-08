using DataKeeper.Framework.Entities;
using DataKeeper.Framework.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataKeeper.Framework.Domain
{
    public class QueryPropertyContext<TProperty> where TProperty : PropertyEntity
    {
        public Guid UserId { get; set; }
        public IDbContextProvider ContextProvider { get; set; }
    }
}
