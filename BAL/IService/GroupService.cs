using BAL.interfaceCalsses;
using BAL.ViewModel;
using DAL.interfaceCalsses;
using DAL.Models;
using DAL.Models.TableFilters;
using DAL.Models.TableViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace BAL.IService
{
    public class GroupService : IGroupService
    {
        IGroup _GroupRepo;
        public GlobalVar._SaveMode SaveMode { get; set; }
        public virtual clsGroup Group {  get; set; }
        public GroupService(IGroup group)
        {
            _GroupRepo = group;
        }
        public List<clsGroup> GetGroupList()
        {
            return _GroupRepo.GetGroupList();
        }


    }
}
