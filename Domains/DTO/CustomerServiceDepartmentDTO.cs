namespace Domains.DTO
{
    public class CustomerServiceDepartmentDTO : BaseDepartmentDTO
    {
        public int ComplexObjectId { get; set; }
        public LogisticsDepartmentDTO LogisticsDepartment { get; set; }
        public SalesDepartmentDTO SalesDepartment { get; set; }
        public override int Employees
        {
            get
            {
                return LogisticsDepartment.Employees + SalesDepartment.Employees;
            }

        }
    }
}
