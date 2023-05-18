using Entities.Departments.Production;

namespace Entities.Departments
{
    public class ProductionDepartment : BaseDepartment
    {
        public int ComplexObjectId { get; set; }
        public EngineeringDepartment EngineeringDepartment { get; set; }
        public PurchasingDepartment PurchasingDepartment { get; set; }
        public QualityControlDepartment QualityControlDepartment { get; set; }
    }
}
