namespace Domains.DTO
{
    public abstract class BaseDepartmentDTO
    {
        public int Id { get; set; }
        public virtual int Employees { get; set; }
    }
}
