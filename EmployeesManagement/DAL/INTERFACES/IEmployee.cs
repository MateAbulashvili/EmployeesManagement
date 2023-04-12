using EmployeesManagement.DAL.DTO;
using EmployeesManagement.Models;
using System;
using System.Threading.Tasks;

namespace EmployeesManagement.DAL.INTERFACES
{
    public interface IEmployee
    {
        public bool AddOrEdit(EmployeeDTO model);
        public bool Delete(int id);

    }
}
