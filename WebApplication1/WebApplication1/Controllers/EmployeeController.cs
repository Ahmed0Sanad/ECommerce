using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.context;
using WebApplication1.Models;
namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        ContextDb context = new ContextDb();



        [HttpGet("getAll")]
        public IActionResult GetAllEmployees()
        {
            var employees = context.employees.ToList();
            return Ok(employees);
        }


        [HttpGet("GetOne/{id:int}")]
        public IActionResult GetEmployee(int id)
        {
            var employee = context.employees.Where(x => x.id == id);
            return Ok(employee);

        }

        [HttpPost]
        public IActionResult SetEployee(Employee employee)
        {
           context.employees.Add(employee);
            context.SaveChanges();
            return Ok(context.employees);

        }
        [HttpPut("{id:int}")]
        public IActionResult UpdateEmployee(int id,Employee employee)
        {

           var emp= context.employees.Single(e => e.id == id);
        
             emp.name=employee.name;
            emp.age=employee.age;
            emp.salary=employee.salary;
            context
                .SaveChanges();
            return Ok(emp);

        }
        [HttpDelete("{id:int}")]
        public IActionResult DeleteEmployee(int id) 
        {
            var employee = context.employees.Single(e=>e.id == id);
           context.employees.Remove(employee);
            context.SaveChanges();
            return Ok(employee);


        }
    }
}
