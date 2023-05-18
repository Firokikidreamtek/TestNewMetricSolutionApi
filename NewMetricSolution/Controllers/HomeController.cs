using AutoMapper;
using Domains.DTO;
using Entities;
using Microsoft.AspNetCore.Mvc;
using NewMetricSolution.DB;
using NewMetricSolution.DB.DBContexts;
using System.Dynamic;
using System.Reflection;

namespace NewMetricSolution.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployeesBase _context;
        private readonly IMapper _mapper;
        private ComplexObjectDTO _complexObject;


        public HomeController(IMapper mapper, IEmployeesBase context)
        {
            _mapper = mapper;
            _context = context;
            var entityObj = _context.CreateComplexObjectForView();
            _complexObject = _mapper.Map<ComplexObjectDTO>(entityObj);
        }

        public IActionResult Index()
        {
            return View(_complexObject);
        }

        public IActionResult IncreaseNumberOfEmployees(string department)
        {
            FindDepartmentAndIncreaseItNumberOfEmployees(_complexObject, department);
            _context.IncreaseNumberOfEmployees(_complexObject);
            return RedirectToAction("Index");
        }




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