﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataKeeper.Framework.Entities
{
    public abstract class PropertyValueEntity : UserEntity
    {
        public virtual Guid PropertyId { get; set; }
        public virtual string Value { get; set; }

        public abstract void SetInstance(Guid id);
    }
}
