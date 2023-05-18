namespace Domains.DTO
{
    public class LogisticsDepartmentDTO : BaseDepartmentDTO
    {
        public int CustomerServiceDepartmentId { get; set; }
        public StorageDepartmentDTO StorageDepartment { get; set; }
        public DeliveryDepartmentDTO DeliveryDepartment { get; set; }

        public override int Employees
        {
            get
            {
                return StorageDepartment.Employees + DeliveryDepartment.Employees;
            }

        }
    }
}
