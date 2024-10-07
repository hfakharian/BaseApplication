using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Base
{

    public abstract class BaseEntity<T> : IBaseEntity where T : notnull
    {
        public T? ID { get; set; }
        public bool IsDeleted { get; set; } = false;
        public DateTime DateCreate { get; set; }
        public DateTime? DateUpdate { get; set; }
    }
}
