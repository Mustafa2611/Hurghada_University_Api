using Final_Project.Core.Models;
using FinalProject.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project.Core.IRepositories
{
    public interface IAdminRepository : IBaseRepository<Admin>
    {
        public Task<Admin> AdminLogin(string email , string password);
    }
}
