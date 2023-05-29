using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewMetricSolution.DB.DBContexts;
using NewMetricSolution.Models;
using System.Net;

namespace NewMetricSolution.Controllers
{
    [Route("api/")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private ApiResponse _response;


        public DepartmentsController(ApplicationDbContext context)
        {
            _context = context;
            _response = new();
            _context = context;
        }

        [Route("CustomServiceDepartment")]
        [HttpGet]
        public async Task<IActionResult> GetCustomServiceDepartment()
        {
            _response.Result = await _context.CustomerServiceDepartment.Include(x => x.LogisticsDepartment).Include(x => x.SalesDepartment)
                .AsNoTracking()
                .FirstOrDefaultAsync();
            if (_response.Result == null)
            {
                _response.StatusCode = HttpStatusCode.NotFound;
                _response.IsSuccess = false;
                return NotFound(_response);
            }
            _response.StatusCode = HttpStatusCode.OK;
            return Ok(_response);
        }

        [Route("CustomServiceDepartment/LogisticsDepartment")]
        [HttpGet]
        public async Task<IActionResult> GetLogisticsDepartment()
        {
            _response.Result = await _context.LogisticsDepartment.Include(x => x.DeliveryDepartment).Include(x => x.StorageDepartment)
                .AsNoTracking()
                .FirstOrDefaultAsync();
            if (_response.Result == null)
            {
                _response.StatusCode = HttpStatusCode.NotFound;
                _response.IsSuccess = false;
                return NotFound(_response);
            }
            _response.StatusCode = HttpStatusCode.OK;
            return Ok(_response);
        }

        [Route("CustomServiceDepartment/SalesDepartment")]
        [HttpGet]
        public async Task<IActionResult> GetSalesDepartment()
        {
            _response.Result = await _context.SalesDepartment.Include(x => x.RetailSalesDepartment).Include(x => x.WholesaleSalesDepartment)
                .AsNoTracking()
                .FirstOrDefaultAsync();
            if (_response.Result == null)
            {
                _response.StatusCode = HttpStatusCode.NotFound;
                _response.IsSuccess = false;
                return NotFound(_response);
            }
            _response.StatusCode = HttpStatusCode.OK;
            return Ok(_response);
        }

        [Route("CustomServiceDepartment/LogisticsDepartment")]
        [HttpPost]
        public ActionResult<ApiResponse> UpdateLogisticsDepartment(
            int quantityOfEmployeesInDeliveryDepartment,
            int quantityOfEmployeesInStorageDepartment)
        {
            int quantityOfEmployeesInLogisticsDepartment = quantityOfEmployeesInDeliveryDepartment + quantityOfEmployeesInStorageDepartment;
            _context.StorageDepartment.FirstOrDefaultAsync().Result.Employees = quantityOfEmployeesInStorageDepartment;
            _context.DeliveryDepartment.FirstOrDefaultAsync().Result.Employees = quantityOfEmployeesInDeliveryDepartment;
            _context.LogisticsDepartment.FirstOrDefaultAsync().Result.Employees = quantityOfEmployeesInLogisticsDepartment;
            int quantityOfRecords = _context.SaveChangesAsync().Result;
            UpdateCustomServiceDepartment();
            if (quantityOfRecords == 0)
            {
                _response.StatusCode = HttpStatusCode.NotFound;
                _response.IsSuccess = false;
                return NotFound(_response);
            }
            _response.StatusCode = HttpStatusCode.OK;
            return Ok(_response);
        }

        [Route("CustomServiceDepartment/SalesDepartment")]
        [HttpPost]
        public ActionResult<ApiResponse> UpdateSalesDepartment(
            int quantityOfEmployeesInRetailSalesDepartment,
            int quantityOfEmployeesInWholesaleSalesDepartment)
        {
            int quantityOfEmployeesInSalesDepartment = quantityOfEmployeesInRetailSalesDepartment + quantityOfEmployeesInWholesaleSalesDepartment;
            _context.WholesaleSalesDepartment.FirstOrDefaultAsync().Result.Employees = quantityOfEmployeesInWholesaleSalesDepartment;
            _context.RetailSalesDepartment.FirstOrDefaultAsync().Result.Employees = quantityOfEmployeesInRetailSalesDepartment;
            _context.SalesDepartment.FirstOrDefaultAsync().Result.Employees = quantityOfEmployeesInSalesDepartment;
            int quantityOfRecords = _context.SaveChangesAsync().Result;
            UpdateCustomServiceDepartment();
            if (quantityOfRecords == 0)
            {
                _response.StatusCode = HttpStatusCode.NotFound;
                _response.IsSuccess = false;
                return NotFound(_response);
            }
            _response.StatusCode = HttpStatusCode.OK;
            return Ok(_response);
        }

        [Route("ProductionDepartment")]
        [HttpGet]
        public async Task<IActionResult> GetProductionDepartment()
        {
            _response.Result = await _context.ProductionDepartment
                .Include(x => x.EngineeringDepartment)
                .Include(x => x.PurchasingDepartment)
                .Include(x => x.QualityControlDepartment)
                .AsNoTracking()
                .FirstOrDefaultAsync();
            if (_response.Result == null)
            {
                _response.StatusCode = HttpStatusCode.NotFound;
                _response.IsSuccess = false;
                return NotFound(_response);
            }
            _response.StatusCode = HttpStatusCode.OK;
            return Ok(_response);
        }

        [Route("ProductionDepartment")]
        [HttpPost]
        public ActionResult<ApiResponse> UpdateProductionDepartment(
            int quantityOfEmployeesInEngineeringDepartment,
            int quantityOfEmployeesInPurchasingDepartment,
            int quantityOfEmployeesQualityControlDepartment)
        {
            int quantityOfEmployeesInProductionDepartment = quantityOfEmployeesInEngineeringDepartment + quantityOfEmployeesInPurchasingDepartment + quantityOfEmployeesQualityControlDepartment;
            _context.EngineeringDepartment.FirstOrDefaultAsync().Result.Employees = quantityOfEmployeesInEngineeringDepartment;
            _context.PurchasingDepartment.FirstOrDefaultAsync().Result.Employees = quantityOfEmployeesInPurchasingDepartment;
            _context.QualityControlDepartment.FirstOrDefaultAsync().Result.Employees = quantityOfEmployeesQualityControlDepartment;
            _context.ProductionDepartment.FirstOrDefaultAsync().Result.Employees = quantityOfEmployeesInProductionDepartment;
            int quantityOfRecords = _context.SaveChangesAsync().Result;
            if (quantityOfRecords == 0)
            {
                _response.StatusCode = HttpStatusCode.NotFound;
                _response.IsSuccess = false;
                return NotFound(_response);
            }
            _response.StatusCode = HttpStatusCode.OK;
            return Ok(_response);
        }

        [Route("AccountingDepartment")]
        [HttpGet]
        public async Task<IActionResult> GetAccountDepartment()
        {
            _response.Result = await _context.AccountingDepartment
                .AsNoTracking()
                .FirstOrDefaultAsync();
            if (_response.Result == null)
            {
                _response.StatusCode = HttpStatusCode.NotFound;
                _response.IsSuccess = false;
                return NotFound(_response);
            }
            _response.StatusCode = HttpStatusCode.OK;
            return Ok(_response);
        }

        [Route("AccountingDepartment")]
        [HttpPost]
        public async Task<ActionResult<ApiResponse>> UpdateAccountDepartment()
        {
            int employees = _context.AccountingDepartment.FirstOrDefaultAsync().Result.Employees;
            employees++;
            _context.AccountingDepartment.FirstOrDefaultAsync().Result.Employees = employees;
            int quantityOfRecords = await _context.SaveChangesAsync();
            if (quantityOfRecords == 0)
            {
                _response.StatusCode = HttpStatusCode.NotFound;
                _response.IsSuccess = false;
                return NotFound(_response);
            }
            _response.StatusCode = HttpStatusCode.OK;
            return Ok(_response);
        }

        private void UpdateCustomServiceDepartment()
        {
            int employees = _context.CustomerServiceDepartment.FirstOrDefaultAsync().Result.Employees;
            employees++;
            _context.CustomerServiceDepartment.FirstOrDefaultAsync().Result.Employees = employees;
            _context.SaveChanges();
        }
    }
}