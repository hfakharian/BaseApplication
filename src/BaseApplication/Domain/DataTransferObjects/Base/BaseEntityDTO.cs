using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DataTransferObjects.Base
{
    public abstract class BaseEntityDTO<T>
    {
        public T? ID { get; set; }
        //public DateTime DateCreate { get; set; }
        //public DateTime? DateUpdate { get; set; }
    }
}
