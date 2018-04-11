using DataKeeper.Framework.Entities;
using DataKeeper.Framework.Models;
using DataKeeper.Framework.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataKeeper.Framework.Domain
{
    public class QueryEntityPageContext<TEntity> : QueryEntityContext<TEntity>
        where TEntity : UserEntity
    {       
        public PageQueryParas PageQueryParas { get; set; }
    }
}
