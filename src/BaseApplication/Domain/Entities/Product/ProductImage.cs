using Domain.Entities.Base;
using Domain.Entities.Product.Enum;
using Domain.Entities.User.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Product
{

    [Table("ProductImage", Schema = "Product")]
    public class ProductImage : BaseEntity<long>
    {
        public long ProductID {  get; set; }    
        
        public string Image { get; set; }
        public int Sort { get; set; }

        public virtual Product Product { get; set; }

    }
}
