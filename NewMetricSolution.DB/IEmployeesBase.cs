using Domains.DTO;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewMetricSolution.DB
{
    public interface IEmployeesBase
    {
        public ComplexObject CreateComplexObjectForView();
        public void IncreaseNumberOfEmployees(ComplexObjectDTO @object);

    }
}
