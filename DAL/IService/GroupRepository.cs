using DAL.EF;
using DAL.interfaceCalsses;
using DAL.Models;
using DAL.Models.TableFilters;
using DAL.Models.TableViews;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL.IService
{
    public class GroupRepository : IGroup
    {
        AppDBContext _Context;
        public GroupRepository(AppDBContext context)
        {
            _Context = context;
        }

        public List<clsGroup> GetGroupList()
        {
            return _Context.Groups.ToList();
        }
    }
}
