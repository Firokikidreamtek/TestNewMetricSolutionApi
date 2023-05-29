using Entities;
using Entities.Departments;
using Entities.Departments.CustomerService;
using Entities.Departments.CustomerService.Logistic;
using Entities.Departments.CustomerService.Sales;
using Entities.Departments.Production;
using Microsoft.EntityFrameworkCore;

namespace NewMetricSolution.DB.DBContexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<CustomerServiceDepartment> CustomerServiceDepartment { get; set; }

        public DbSet<SalesDepartment> SalesDepartment { get; set; }
        public DbSet<RetailSalesDepartment> RetailSalesDepartment { get; set; }
        public DbSet<WholesaleSalesDepartment> WholesaleSalesDepartment { get; set; }

        public DbSet<LogisticsDepartment> LogisticsDepartment { get; set; }
        public DbSet<DeliveryDepartment> DeliveryDepartment { get; set; }
        public DbSet<StorageDepartment> StorageDepartment { get; set; }

        public DbSet<ProductionDepartment> ProductionDepartment { get; set; }
        public DbSet<EngineeringDepartment> EngineeringDepartment { get; set; }
        public DbSet<PurchasingDepartment> PurchasingDepartment { get; set; }
        public DbSet<QualityControlDepartment> QualityControlDepartment { get; set; }

        public DbSet<AccountingDepartment> AccountingDepartment { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Customer
            var customer = new CustomerServiceDepartment { Id = 1, Employees = 11};
            modelBuilder.Entity<CustomerServiceDepartment>().HasData(customer);
            #region Sales
            var allSales = new SalesDepartment { Id = 1, Employees = 4, CustomerServiceDepartmentId = customer.Id };
            var retail = new RetailSalesDepartment() { Id = 1, Employees = 2, SalesDepartmentId = allSales.Id };
            var whole = new WholesaleSalesDepartment() { Id = 1, Employees = 2, SalesDepartmentId = allSales.Id };
            modelBuilder.Entity<SalesDepartment>().HasData(allSales);
            modelBuilder.Entity<WholesaleSalesDepartment>().HasData(whole);
            modelBuilder.Entity<RetailSalesDepartment>().HasData(retail);
            #endregion

            #region Logistic
            var logistic = new LogisticsDepartment { Id = 1, Employees = 7, CustomerServiceDepartmentId= customer.Id };
            var delivery = new DeliveryDepartment() { Id = 1, Employees = 5, LogisticsDepartmentId = logistic.Id };
            var storage = new StorageDepartment() { Id = 1, Employees = 2, LogisticsDepartmentId = logistic.Id };
            modelBuilder.Entity<LogisticsDepartment>().HasData(logistic);
            modelBuilder.Entity<DeliveryDepartment>().HasData(delivery);
            modelBuilder.Entity<StorageDepartment>().HasData(storage);
            #endregion

            #endregion

            #region Production
            var production = new ProductionDepartment { Id = 1, Employees = 7};
            var engineering = new EngineeringDepartment() { Id = 1, Employees = 4, ProductionDepartmentId = production.Id };
            var qualityControl = new QualityControlDepartment() { Id = 1, Employees = 2, ProductionDepartmentId = production.Id };
            var purchasing = new PurchasingDepartment() { Id = 1, Employees = 1, ProductionDepartmentId = production.Id };
            modelBuilder.Entity<ProductionDepartment>().HasData(production);
            modelBuilder.Entity<EngineeringDepartment>().HasData(engineering);
            modelBuilder.Entity<QualityControlDepartment>().HasData(qualityControl);
            modelBuilder.Entity<PurchasingDepartment>().HasData(purchasing);
            #endregion

            #region Accounting
            var accounting = new AccountingDepartment { Id = 1, Employees = 2};
            modelBuilder.Entity<AccountingDepartment>().HasData(accounting);
            #endregion
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=usersdb;Username=postgres;Password=пароль_от_postgres");
        //}
    }
}
