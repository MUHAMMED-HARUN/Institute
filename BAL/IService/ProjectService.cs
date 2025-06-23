using BAL.interfaceCalsses;
using DAL.interfaceCalsses;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.IService
{
    public class ProjectService : IProjectService
    {
        IProject _project;
        public ProjectService(IProject project)
        {
            _project = project;
        }
        public virtual clsProject Project {  get; set; }

        public List<clsProject> GetAll()
        {
            return _project.GetALL();
        }

    }
}
