﻿using AutoMapper;
using EmployeesManagement.DAL.DTO;
using EmployeesManagement.DAL.REPOSITORY;
using EmployeesManagement.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.UI.V3.Pages.Internal.Account;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesManagement.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeDbContext _context;
        private readonly EmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;
        public EmployeeController(EmployeeDbContext context, EmployeeRepository employeeRepository,IMapper mapper)
        {
            _context = context;
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        // GET: EmployeeController
        [Authorize]
        public IActionResult Index(string searchString)
        {
            var Dbresult = _context.Employees.ToList();
            var mapper = _mapper.Map<List<EmployeeDTO>>(Dbresult);

            return View(mapper);

            //var employees = _context.Employees.AsEnumerable();

            //if (!string.IsNullOrEmpty(searchString))
            //{
            //    employees = employees.Where(e => e.FirstName.Contains(searchString) ||
            //                                     e.LastName.Contains(searchString) ||
            //                                     e.PersonalNumber.Contains(searchString) ||
            //                                     e.Email.Contains(searchString));
            //}

            //return View(employees);
        }

        // GET: EmployeeController/Details/5
        public IActionResult Details(int id)
        {
            return View();
        }

        // GET: EmployeeController/AddOrEdit
        [Authorize]

        public IActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
            {
                return View(new EmployeeModel());
            }
            else
                return View(_context.Employees.Find(id));
        }


        // POST: EmployeeController/AddOrEdit
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([Bind("Id,FirstName,LastName,PersonalNumber,Email,Password,Gender,DOB,Position,Status,FiredDate,Phone")] EmployeeDTO model)
        {
            try
            {

                if (ModelState.IsValid)
                {

                    var result = _employeeRepository.AddOrEdit(model);
                    if (result)
                    {
                        return RedirectToAction(nameof(Index));
                    }

                    
                }
                return View("Model State not valid");

            }
            catch(Exception ex )
            {
                return BadRequest(new { ErrorMsg = ex.Message });
            }
        }
        
        // POST: EmployeeController/Delete/5
        [HttpPost,ActionName("Delete")]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {                
                var userToDelete = _employeeRepository.Delete(id);
                if (userToDelete)
                {
                    return RedirectToAction(nameof(Index));
                }
                else 
                    return View();
            }
            catch(Exception ex)
            {
                return BadRequest(new { ErrorMsg = ex.Message });
            }
        }
    }
}
