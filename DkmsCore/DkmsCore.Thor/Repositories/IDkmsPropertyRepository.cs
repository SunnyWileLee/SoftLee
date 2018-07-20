using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DkmsCore.Thor.Repositories
{
    public interface IDkmsPropertyRepository
    {
        Task<Guid> AddProperty<TProperty>(TProperty property) where TProperty : DkmsPropertyEntity;
    }
}
