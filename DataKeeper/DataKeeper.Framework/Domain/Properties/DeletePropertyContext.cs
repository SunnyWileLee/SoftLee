using DataKeeper.Framework.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataKeeper.Framework.Domain.Properties
{
    public class DeletePropertyContext<TProperty> : AccessDbContext
        where TProperty : PropertyEntity
    {
        public Guid Id { get; set; }
    }
}
