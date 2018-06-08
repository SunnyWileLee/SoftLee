using System;

namespace DkmsCore.Repository
{
    public class DkmsEntity
    {
        public DkmsEntity()
        {
            Id = Guid.NewGuid();
            CreateTime = DateTime.Now;
        }

        public Guid Id { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
