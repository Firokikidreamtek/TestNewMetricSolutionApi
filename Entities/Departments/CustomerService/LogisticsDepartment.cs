using Entities.Departments.CustomerService.Logistic;

namespace Entities.Departments.CustomerService
{
    public class LogisticsDepartment : BaseDepartment
    {
        public int CustomerServiceDepartmentId { get; set; }
        public StorageDepartment StorageDepartment { get; set; }
        public DeliveryDepartment DeliveryDepartment { get; set; }
    }
}
