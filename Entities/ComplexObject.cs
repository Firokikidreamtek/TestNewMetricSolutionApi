using Entities.Departments;

namespace Entities
{
    public class ComplexObject
    {
        public int Id { get; set; }
        public ProductionDepartment ProductionDepartment { get; set; }
        public CustomerServiceDepartment CustomerServiceDepartment { get; set; }
        public AccountingDepartment AccountingDepartment { get; set; }
    }
}
