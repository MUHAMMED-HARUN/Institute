using DAL.EF;
using DAL.interfaceCalsses;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IService
{
    public class ProjectRepository : IProject
    {
        AppDBContext _Context;
        public ProjectRepository(AppDBContext context)
        {
            _Context = context;
        }
        public List<clsProject> GetALL()
        {
           return _Context.Projects.ToList();
        }

    }
}
