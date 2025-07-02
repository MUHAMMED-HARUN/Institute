using BAL.ViewModel;
using DAL.Models;
using DAL.Models.TableFilters;
using DAL.Models.TableViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace BAL.interfaceCalsses
{
    public interface IGroupService
    {
        public GlobalVar._SaveMode SaveMode { get; set; }
     public clsGroup  Group { get; set; }
        public List<clsGroup> GetGroupList();
    }
}
