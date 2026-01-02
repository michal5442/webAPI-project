using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public record ProductManagerDTO
        (
            string ProductName,
            double? Price,
            int CategoryId,
            string Description
        );

}
