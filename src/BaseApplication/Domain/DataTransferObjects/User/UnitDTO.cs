using Domain.DataTransferObjects.Base;
using Domain.Entities.User;
using Domain.Entities.User.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DataTransferObjects.User
{
    public class UnitDTO : BaseEntityDTO<int?>
    {

        public UnitType UnitType { get; set; }
        public BaseEnumModel? UnitTypeModel { get; set; }
        public List<BaseEnumModel>? UnitTypeModels { get; set; }

        public UnitStatus UnitStatus { get; set; }
        public BaseEnumModel? UnitStatusModel { get; set; }
        public List<BaseEnumModel>? UnitStatusModels { get; set; }

        public string Title { get; set; }
        public string? Website { get; set; }
        public string? Email { get; set; }

        public UnitDetailDTO? UnitDetail { get; set; }
    }
}
