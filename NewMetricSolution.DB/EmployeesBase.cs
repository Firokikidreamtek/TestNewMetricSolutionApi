using AutoMapper;
using Domains.DTO;
using Entities;
using Entities.Departments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NewMetricSolution.DB.DBContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NewMetricSolution.DB
{
    public class EmployeesBase : IEmployeesBase
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _databaseContext;

        public EmployeesBase(ApplicationDbContext databaseContext, IMapper mapper)
        {
            _databaseContext = databaseContext;
            _mapper = mapper;
        }


        public ComplexObject CreateComplexObjectForView()
        {
            var complexObject = _databaseContext.ComplexObject
                               .Include(x => x.CustomerServiceDepartment).ThenInclude(x => x.SalesDepartment).ThenInclude(x => x.RetailSalesDepartment)
                               .Include(x => x.CustomerServiceDepartment).ThenInclude(x => x.SalesDepartment).ThenInclude(x => x.WholesaleSalesDepartment)
                               .Include(x => x.CustomerServiceDepartment).ThenInclude(x => x.LogisticsDepartment).ThenInclude(x => x.DeliveryDepartment)
                               .Include(x => x.CustomerServiceDepartment).ThenInclude(x => x.LogisticsDepartment).ThenInclude(x => x.StorageDepartment)
                               .Include(x => x.ProductionDepartment).ThenInclude(x => x.PurchasingDepartment)
                               .Include(x => x.ProductionDepartment).ThenInclude(x => x.QualityControlDepartment)
                               .Include(x => x.ProductionDepartment).ThenInclude(x => x.EngineeringDepartment)
                               .Include(x => x.AccountingDepartment).AsNoTracking().FirstOrDefault();
            return complexObject;
        }

        private ComplexObject CreateComplexObject()
        {
            var complexObject = _databaseContext.ComplexObject
                               .Include(x => x.CustomerServiceDepartment).ThenInclude(x => x.SalesDepartment).ThenInclude(x => x.RetailSalesDepartment)
                               .Include(x => x.CustomerServiceDepartment).ThenInclude(x => x.SalesDepartment).ThenInclude(x => x.WholesaleSalesDepartment)
                               .Include(x => x.CustomerServiceDepartment).ThenInclude(x => x.LogisticsDepartment).ThenInclude(x => x.DeliveryDepartment)
                               .Include(x => x.CustomerServiceDepartment).ThenInclude(x => x.LogisticsDepartment).ThenInclude(x => x.StorageDepartment)
                               .Include(x => x.ProductionDepartment).ThenInclude(x => x.PurchasingDepartment)
                               .Include(x => x.ProductionDepartment).ThenInclude(x => x.QualityControlDepartment)
                               .Include(x => x.ProductionDepartment).ThenInclude(x => x.EngineeringDepartment)
                               .Include(x => x.AccountingDepartment).FirstOrDefault();
            return complexObject;
        }

        public void IncreaseNumberOfEmployees(ComplexObjectDTO @object)
        {
            var complexObject = CreateComplexObject();
            complexObject = _mapper.Map(@object, complexObject);
            _databaseContext.SaveChanges();
        }

    }
}
