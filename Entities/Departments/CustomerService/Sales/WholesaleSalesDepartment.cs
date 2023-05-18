using Entities.Departments;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Departments.CustomerService.Sales
{
    public class WholesaleSalesDepartment : BaseDepartment
    {
        public int SalesDepartmentId { get; set; }
    }
}
