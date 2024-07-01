using EmpData;
using EmpData.Emp_Data;
using EmpModel.Model;
using EmpServices.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpServices.Implementation
{
    public class Emp_Services: IEmployeeServices
    {
        private readonly  ApplicationDbContext _context;
        public Emp_Services (ApplicationDbContext context)
        {
            _context = context;
        }

        public Emp_Model AddEmployee(Emp_Model emp)
        {
            EmpTableEntities ent=new EmpTableEntities();
            ent.Id = emp.Id;
            ent.Name = emp.Name;
            ent.Salary = emp.Salary;
            ent.Designation = emp.Designation;
            _context.RBM.Add(ent);   
           
            _context.SaveChanges(); 
            return emp;
        }
        //Get Employee By Id
        public EmpTableEntities GetEmployeeById(int id)
        {
            var employee = _context.RBM.FirstOrDefault(i => i.Id == id);
            _context.SaveChanges();
            return employee;
             
            
        }
        //Get all Employee
        public List<EmpTableEntities> GetEmployee()
        {
            var employees = _context.RBM.ToList();
            return employees;
        }

        //update the Employee
        public EmpTableEntities PutEmployee(int id, EmpTableEntities emp)
        {
            var existingItem = _context.RBM.FirstOrDefault(i => i.Id == id);
            if (existingItem == null)
            {
                return null; 
            }
            existingItem.Name = emp.Name;
            existingItem.Salary = emp.Salary;
            existingItem.Designation = emp.Designation;
            _context.RBM.Update(existingItem);

            
          _context.SaveChanges();

            return existingItem;
        }

        //Delete Employee ById
        public string DeleteEmployeeById(int id)
        {
            var existingEmployee = _context.RBM.FirstOrDefault(i => i.Id == id);
            if (existingEmployee == null)
            {
                return "Employee not found";
            }

            _context.RBM.Remove(existingEmployee);
            _context.SaveChanges();

            return "Employee removed";
        }



    }
}
