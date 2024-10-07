using Domain.Entities.Base;
using Domain.Entities.Product.Enum;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Product
{

    [Table("Category", Schema = "Product")]
    public class Category : BaseEntity<int>
    {
        public int? CategoryParentID { get; set; }
        public CategoryType CategoryType { get; set; }
        public CategoryStatus CategoryStatus { get; set; }
        public string Title { get; set; }
        public string? Comment { get; set; }
        public int Sort { get; set; }


        public Category? CategoryParent { get; set; }
        public virtual ICollection<Product>? Products { get; set; }

    }
}
