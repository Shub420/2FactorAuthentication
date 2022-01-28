using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication2factor.Models;
using WebApplication2factor.Repository.IRepository;

namespace WebApplication2factor.Repository
{
    public class EmployeeRepository:Repository<Employee>,IEmployeeRepository
    {
        private readonly ApplicationDbContext _context;
        public EmployeeRepository(ApplicationDbContext context ):base(context)
        {
            _context = context;
        }

     
    }
}