using Final_Project.Core.IRepositories;
using Final_Project.Core.Models;
using Final_Project.EF.Configuration;
using Final_Project.EF.RepositoriesImplementation;
using FinalProject.Core;
using FinalProject.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project.EF
{
    public class UnitOfWorkImp : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public UnitOfWorkImp(ApplicationDbContext context)
        {
             _context = context;
            Events = new EventRepositoryImp(_context);
            News = new NewsRepositoryImp(_context);
            Departments = new DepartmentRepositoryImp(_context);
            Employees = new EmployeeRepositoryImp(_context);
            Courses = new CourseRepositoryImp(_context);
            Colleges = new CollegeRepositoryImp(_context);
            Units = new UnitRepositoryImp(_context);
            Admins = new AdminRepositoryImp(_context); 
            Qualities = new QualityRepositoryImp(_context);
        }

        public IEventRepository Events { get; private set; }
        public INewsRepository News { get; private set; }
        public IDepartmentRepository Departments { get; private set; }
        public IEmployeeRepository Employees { get; private set; }
        public ICourseRepository Courses { get; private set; }
        public ICollegeRepository Colleges { get; private set; }
        public IUnitRepository Units { get; private set; }
        public IAdminRepository Admins { get; private set; }
        public IQualityRepository Qualities { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}


