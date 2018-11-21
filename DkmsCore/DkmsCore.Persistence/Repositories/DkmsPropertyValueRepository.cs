using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DkmsCore.Persistence.Repositories
{
    public class DkmsPropertyValueRepository : IDkmsPropertyValueRepository
    {
        private readonly IDkmsRepository _dkmsRepository;

        public DkmsPropertyValueRepository(IDkmsRepository dkmsRepository)
        {
            _dkmsRepository = dkmsRepository;
        }

        public virtual async Task<Guid> AddAsync<TPropertyValueEntity>(TPropertyValueEntity entity) where TPropertyValueEntity : DkmsPropertyValueEntity
        {
            return await _dkmsRepository.AddAsync(entity);
        }

        public virtual async Task<List<TPropertyValueEntity>> GetListAsync<TPropertyValueEntity>(Expression<Func<TPropertyValueEntity, bool>> predicate) where TPropertyValueEntity : DkmsPropertyValueEntity
        {
            var list = await _dkmsRepository.GetListAsync(predicate);
            return list;
        }

        public virtual async Task<List<TPropertyValueEntity>> GetListAsync<TPropertyValueEntity>(Guid userId, Guid instanceId) where TPropertyValueEntity : DkmsPropertyValueEntity
        {
            return await GetListAsync<TPropertyValueEntity>(s => s.UserId == userId && s.InstanceId == instanceId);
        }

        public virtual async Task<List<TPropertyValueEntity>> GetListAsync<TPropertyValueEntity>(Guid userId, IEnumerable<Guid> instanceIds) where TPropertyValueEntity : DkmsPropertyValueEntity
        {
            return await GetListAsync<TPropertyValueEntity>(s => s.UserId == userId && instanceIds.Contains(s.InstanceId));
        }
    }
}
