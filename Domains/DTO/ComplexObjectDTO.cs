using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domains.DTO
{
    public class ComplexObjectDTO
    {
        public ProductionDepartmentDTO ProductionDepartment { get; set; }
        public CustomerServiceDepartmentDTO CustomerServiceDepartment { get; set; }
        public AccountingDepartmentDTO AccountingDepartment { get; set; }
    }
}
