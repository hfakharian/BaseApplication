using Domain.Entities.Base;
using Domain.Entities.Product.Enum;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Product
{

    [Table("Product", Schema = "Product")]
    public class Product : BaseEntity<long>
    {
        public int CategoryID {  get; set; }    
        
        public ProductType ProductType { get; set; }
        public ProductStatus ProductStatus { get; set; }
        public string Title { get; set; }
        public string? Comment { get; set; }
        public int rate { get; set; }

        public virtual Category Category { get; set; }

        public virtual ICollection<ProductImage> ProductImages { get; set; }

    }
}
