﻿using Entities.Departments.CustomerService;

namespace Entities.Departments
{
    public class CustomerServiceDepartment : BaseDepartment
    {
        public LogisticsDepartment LogisticsDepartment { get; set; }
        public SalesDepartment SalesDepartment { get; set; }
    }
}
