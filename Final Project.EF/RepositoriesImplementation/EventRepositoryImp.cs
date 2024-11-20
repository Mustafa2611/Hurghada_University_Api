using Final_Project.Core.Models;
using Final_Project.EF.Configuration;
using FinalProject.Core.IRepositories;
using FinalProject.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project.EF.RepositoriesImplementation
{
    public class EventRepositoryImp : BaseRepositoryImp<Event> , IEventRepository
    {
        public EventRepositoryImp(ApplicationDbContext context) : base(context)
        {
        }
        
       
        

        
    }
}
