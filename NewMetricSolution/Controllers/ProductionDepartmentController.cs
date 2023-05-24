using AutoMapper;
using Domains.DTO;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewMetricSolution.DB;
using NewMetricSolution.DB.DBContexts;
using System.Dynamic;
using System.Net;
using System.Reflection;

namespace NewMetricSolution.Controllers
{
    [Route("api/")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private ComplexObjectDTO _complexObject;
        private ApiResponse _response;


        public HomeController(ApplicationDbContext context)
        {
            _context = context;
            _response = new ();
            _context = context;
        }

        [Route("ProductionDepartment")]
        [HttpGet]
        public async Task<IActionResult> GetProductionDepartment()
        {
            _response.Result = await _context.ProductionDepartment
                .Include(x => x.EngineeringDepartment)
                .Include(x => x.PurchasingDepartment)
                .Include(x => x.QualityControlDepartment)
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


        //public IActionResult IncreaseNumberOfEmployees(string department)
        //{
        //    FindDepartmentAndIncreaseItNumberOfEmployees(_complexObject, department);
        //    _context.IncreaseNumberOfEmployees(_complexObject);
        //    return RedirectToAction("Index");
        //}




        private void FindDepartmentAndIncreaseItNumberOfEmployees(object o, string department)
        {
            Type t = o.GetType();
            PropertyInfo[] props = t.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prp in props)
            {
                if (t.Name.Contains(department))
                {
                    var employeesProps = t.GetProperty("Employees");
                    int value = (int)employeesProps.GetValue(o);
                    value++;
                    employeesProps.SetValue(o, value);
                    break;
                }
                else
                {
                    FindDepartmentAndIncreaseItNumberOfEmployees(prp.GetValue(o), department);
                }
            }
        }
    }
}