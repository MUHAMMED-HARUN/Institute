using DAL.Models;
using DAL.Models.TableFilters;
using DAL.Models.TableViews;
using ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.interfaceCalsses
{
    public interface IGroup
    {
        public List<clsGroup> GetGroupList();
    }
}
