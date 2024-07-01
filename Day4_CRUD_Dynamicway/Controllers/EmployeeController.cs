using EmpData.Emp_Data;
using EmpModel.Model;
using EmpServices.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Day4_CRUD_Dynamicway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeServices _services;

        public EmployeeController(IEmployeeServices services)
        {
            _services = services;
        }   

        [HttpPost]

        public IActionResult AddEmp(Emp_Model Model) 
        {
         var HM= _services.AddEmployee(Model);
            return Ok(HM);
        }

        [HttpGet("id")]

        public IActionResult GetEmployeebyId(int id)
        {
            var employee = _services.GetEmployeeById(id);
            return Ok(employee);
            
        }

        [HttpGet]

        public IActionResult GetEmployee()
        {
            var employee = _services.GetEmployee();
            return Ok(employee);

        }
        [HttpPut("{id}")]
        public IActionResult PutEmployee(int id, EmpTableEntities emp)
        {
            var employee = _services.PutEmployee(id, emp);
            return Ok(employee);
        }

        // DELETE: api/Items/5
      
        
        [HttpDelete("{id}")]
        public string DeleteEmployeeById(int id)
        {
            return _services.DeleteEmployeeById(id);
        }


    }
}
