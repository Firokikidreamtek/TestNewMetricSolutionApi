using Entities.Departments;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Departments.CustomerService.Sales
{
    public class RetailSalesDepartment : BaseDepartment
    {
        public int SalesDepartmentId { get; set; }
    }
}
