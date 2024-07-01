using EmpData.Emp_Data;
using EmpModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpServices.Interface
{
    public  interface IEmployeeServices
    {
        public Emp_Model AddEmployee(Emp_Model emp);
        public EmpTableEntities GetEmployeeById(int id);
        // public EmpTableEntities GetEmployee();
        public List<EmpTableEntities> GetEmployee(); 
        public EmpTableEntities PutEmployee(int id, EmpTableEntities emp);
        public string DeleteEmployeeById(int id);
    }
}
