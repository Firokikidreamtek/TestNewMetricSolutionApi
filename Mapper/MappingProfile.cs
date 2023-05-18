using AutoMapper;
using Domains.DTO;
using Entities;
using Entities.Departments;
using Entities.Departments.CustomerService;
using Entities.Departments.CustomerService.Logistic;
using Entities.Departments.CustomerService.Sales;
using Entities.Departments.Production;

namespace Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CustomerServiceDepartmentDTO, CustomerServiceDepartment>().ReverseMap();
            CreateMap<SalesDepartmentDTO, SalesDepartment>().ReverseMap();
            CreateMap<RetailSalesDepartmentDTO, RetailSalesDepartment>().ReverseMap();
            CreateMap<WholesaleSalesDepartmentDTO, WholesaleSalesDepartment>().ReverseMap();
            CreateMap<LogisticsDepartmentDTO, LogisticsDepartment>().ReverseMap();
            CreateMap<DeliveryDepartmentDTO, DeliveryDepartment>().ReverseMap();
            CreateMap<StorageDepartmentDTO, StorageDepartment>().ReverseMap();
            CreateMap<ProductionDepartmentDTO, ProductionDepartment>().ReverseMap();
            CreateMap<EngineeringDepartmentDTO, EngineeringDepartment>().ReverseMap();
            CreateMap<PurchasingDepartmentDTO, PurchasingDepartment>().ReverseMap();
            CreateMap<QualityControlDepartmentDTO, QualityControlDepartment>().ReverseMap();
            CreateMap<AccountingDepartmentDTO, AccountingDepartment>().ReverseMap();
            CreateMap<ComplexObjectDTO, ComplexObject>().ReverseMap();
        }
    }
}
