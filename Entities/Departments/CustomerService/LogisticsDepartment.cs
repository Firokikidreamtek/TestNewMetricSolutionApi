using Entities.Departments.CustomerService.Logistic;

namespace Entities.Departments.CustomerService
{
    public class LogisticsDepartment : BaseDepartment
    {
        public int CustomerServiceDepartmentId { get; set; }
        public StorageDepartment StorageDepartment { get; set; }
        public DeliveryDepartment DeliveryDepartment { get; set; }
        private int _employees
        {
            get
            {
                if(DeliveryDepartment != null && StorageDepartment != null) 
                return StorageDepartment.Employees + DeliveryDepartment.Employees;
                else return 0;
            }
        }
        public override int Employees
        {
            get => _employees;
            set => base.Employees = value;
        }
    }
}
