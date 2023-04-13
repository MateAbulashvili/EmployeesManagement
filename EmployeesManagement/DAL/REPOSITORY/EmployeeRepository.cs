using AutoMapper;
using EmployeesManagement.DAL.DTO;
using EmployeesManagement.DAL.INTERFACES;
using EmployeesManagement.Migrations;
using EmployeesManagement.Models;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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


        public EmployeeRepository(EmployeeDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<EmployeeDTO> EmployeeList(string? searchString)
        {
            var Dbresult = _context.Employees.AsEnumerable();

            if (!string.IsNullOrEmpty(searchString))
            {
                Dbresult = Dbresult.Where(e => e.FirstName.Contains(searchString) || e.LastName.Contains(searchString));
            }
            Dbresult.ToList();
            var mapped = _mapper.Map<List<EmployeeDTO>>(Dbresult);
            return mapped;
        }

        public bool AddOrEdit(EmployeeDTO model)
        {
            bool user = GetEmployee(model.Id);
            
            var mapper = _mapper.Map<EmployeeModel>(model);

            if (user)
            {
                bool mailcheck = EmailExists(model.Email,model.Id);
                if (mailcheck)
                {
                    throw new Exception("Person with this Email already exist, please use different email");
                }
                var PrCheck = PNumberExists(model.PersonalNumber, model.Id);
                if (PrCheck)
                {
                    throw new Exception("Person with this Number already exist, please use different number");
                }
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
        public bool EmailExists(string email,int userId)
        {
            return _context.Employees.Any(u => u.Email == email && u.Id != userId);
        }
        public bool PNumberExists(string Pnumber,int userId)
        {
            return _context.Employees.Any(u => u.PersonalNumber == Pnumber && u.Id != userId);
        }
        private bool GetEmployee(int id)
        {
            return _context.Employees.Any(x => x.Id == id);
        }
    }
}
