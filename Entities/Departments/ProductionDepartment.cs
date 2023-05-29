using Entities.Departments.Production;

namespace Entities.Departments
{
    public class ProductionDepartment : BaseDepartment
    {
        public EngineeringDepartment EngineeringDepartment { get; set; }
        public PurchasingDepartment PurchasingDepartment { get; set; }
        public QualityControlDepartment QualityControlDepartment { get; set; }
    }
}
