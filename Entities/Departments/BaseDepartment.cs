using System.ComponentModel.DataAnnotations;

namespace Entities.Departments
{
    public abstract class BaseDepartment
    {
        //[Key]
        public int Id { get; set; }
        public int Employees { get; set; }
    }
}
