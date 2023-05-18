using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domains.DTO
{
    public class WholesaleSalesDepartmentDTO : BaseDepartmentDTO
    {
        public int SalesDepartmentId { get; set; }
    }
}
