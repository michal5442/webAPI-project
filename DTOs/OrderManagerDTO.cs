using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public record OrderManagerDTO
        (
            DateOnly? OrderDate,
            double? OrderSum,
            int? UserId,
            //List<int?> Quantitys,
            //List<string> ProductsName,
            string Status
        );
}
