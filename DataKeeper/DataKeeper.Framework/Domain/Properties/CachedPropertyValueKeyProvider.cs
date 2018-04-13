using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataKeeper.Framework.Domain.Properties
{
    public abstract class CachedPropertyValueKeyProvider : IPropertyValueKeyProvider
    {
        private static Dictionary<Type, string> _caches = new Dictionary<Type, string> { };
        private static object cacheLock = new object { };

        public virtual string Provide<TPropertyValueEntity>()
        {
            var type = typeof(TPropertyValueEntity);
            var key = GetCache(type);
            if (!string.IsNullOrEmpty(key))
            {
                return key;
            }
            lock (cacheLock)
            {
                key = GetCache(type);
                if (!string.IsNullOrEmpty(key))
                {
                    return key;
                }
                key = this.Provide<TPropertyValueEntity>();
                if (!string.IsNullOrEmpty(key))
                {
                    SetCache(type, key);
                }
                return key;
            }
        }

        protected abstract string ProvideMethod(Type type);

        protected virtual string GetCache(Type type)
        {
            if (_caches.ContainsKey(type))
            {
                return _caches[type];
            }
            return string.Empty;
        }

        protected virtual void SetCache(Type type, string key)
        {
            _caches.Add(type, key);
        }
    }
}
