﻿using DataKeeper.Framework.Entities;
using DataKeeper.Framework.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataKeeper.Framework.Domain.Properties
{
    public class AddPropertyContext<TProperty> : AccessDbContext
        where TProperty : PropertyEntity
    {
        public TProperty Property { get; set; }
    }
}
