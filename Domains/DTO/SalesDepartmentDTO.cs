namespace Domains.DTO
{
    public class SalesDepartmentDTO : BaseDepartmentDTO
    {
        public int CustomerServiceDepartmentId { get; set; }
        public RetailSalesDepartmentDTO RetailSalesDepartment { get; set; }
        public WholesaleSalesDepartmentDTO WholesaleSalesDepartment { get; set; }
        public override int Employees
        {
            get
            {
                return WholesaleSalesDepartment.Employees + RetailSalesDepartment.Employees;
            }

        }
    }
}
