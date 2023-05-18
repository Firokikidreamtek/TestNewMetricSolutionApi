using Entities.Departments.CustomerService.Sales;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Departments.CustomerService
{
    public class SalesDepartment : BaseDepartment
    {
        public int CustomerServiceDepartmentId { get; set; }
        public RetailSalesDepartment RetailSalesDepartment { get; set; }
        public WholesaleSalesDepartment WholesaleSalesDepartment { get; set; }
    }
}
