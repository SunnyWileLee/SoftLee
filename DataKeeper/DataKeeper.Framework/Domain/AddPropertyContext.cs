using DataKeeper.Framework.Entities;
using DataKeeper.Framework.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataKeeper.Framework.Domain
{
    public class AddPropertyContext<TProperty> where TProperty : PropertyEntity
    {
        public TProperty Property { get; set; }
        public IDbContextProvider ContextProvider { get; set; }
    }
}
