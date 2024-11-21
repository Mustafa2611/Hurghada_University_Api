using Final_Project.Core.IRepositories;
using Final_Project.Core.Models;
using Final_Project.EF.Configuration;
using FinalProject.Core.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project.EF.RepositoriesImplementation
{
    public class AdminRepositoryImp : BaseRepositoryImp<Admin>, IAdminRepository
    {
        private readonly ApplicationDbContext _context;

        public AdminRepositoryImp(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }



        public async Task<Admin> AdminLogin(string email , string password)
        {
            var admin = await _context.Admins.SingleOrDefaultAsync(a => a.Email == email && a.Password == password);
            if (admin == null) return null;
            return admin;
            //return Task.FromResult(admin);
        }

       
    }
}
