using Final_Project.Core.IRepositories;
using Final_Project.Core.Models;
using Final_Project.EF.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project.EF.RepositoriesImplementation
{
    public class QualityRepositoryImp : BaseRepositoryImp<Quality> , IQualityRepository
    {
        public QualityRepositoryImp(ApplicationDbContext context) : base(context) { 
        
        }
    }
}
