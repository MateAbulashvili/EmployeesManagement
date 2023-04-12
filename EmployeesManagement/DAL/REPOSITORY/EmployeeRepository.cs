using AutoMapper;
using EmployeesManagement.DAL.DTO;
using EmployeesManagement.DAL.INTERFACES;
using EmployeesManagement.Migrations;
using EmployeesManagement.Models;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EmployeesManagement.DAL.REPOSITORY
{
    public class EmployeeRepository : IEmployee
    {
        private readonly EmployeeDbContext _context;
        private readonly IMapper _mapper;


        public EmployeeRepository(EmployeeDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public  bool AddOrEdit(EmployeeDTO model)
        {
            bool user =  _context.Employees.Any(x => x.Id == model.Id);
            var mapper = _mapper.Map<EmployeeModel>(model);
            if (user)
            {

                _context.Employees.Update(mapper);
                _context.SaveChanges();
                
            }
            else
            {
                
               
                
                
                    _context.Employees.Add(mapper);
                    _context.SaveChanges();
                
              
                
                      
            }
            
            return true;
        }

        public bool Delete(int id)
        {
            var user = _context.Employees.Find(id);
            _context.Employees.Remove(user);
            _context.SaveChanges();
            return true;
        }
    }
}
