namespace Domains.DTO
{
    public class ProductionDepartmentDTO : BaseDepartmentDTO
    {
        public int ComplexObjectId { get; set; }
        public EngineeringDepartmentDTO EngineeringDepartment { get; set; }
        public PurchasingDepartmentDTO PurchasingDepartment { get; set; }
        public QualityControlDepartmentDTO QualityControlDepartment { get; set; }
        public override int Employees
        {
            get
            {
                return EngineeringDepartment.Employees + PurchasingDepartment.Employees + QualityControlDepartment.Employees;
            }

        }
    }
}
