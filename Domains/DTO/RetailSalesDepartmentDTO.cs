using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domains.DTO
{
    public class RetailSalesDepartmentDTO : BaseDepartmentDTO
    {
        public int SalesDepartmentId { get; set; }
    }
}
