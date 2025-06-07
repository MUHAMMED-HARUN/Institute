using BAL.interfaceCalsses;
using DAL.interfaceCalsses;
using DAL.IService;
using DAL.Models;
using DAL.Models.TableFilters;
using DAL.Models.TableViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BAL.GlobalVar;

namespace BAL.IService
{
    public class PersonService : IPersonService
    {
        IPerson _PersonRepository;
        public PersonService(IPerson personRepository)
        {
            _PersonRepository = personRepository;
        }
        public _SaveMode SaveMode { get; set; }
        public virtual clsPerson Person { get; set; }
        public virtual clsAddress Address { get; set; }

        public int Add(clsPerson NewPerson, clsAddress address)
        {
            return _PersonRepository.AddNewPerson(NewPerson, address);
        }
        public bool Update(clsPerson person, clsAddress address)
        {
            return _PersonRepository.EditPerson(person, address);
        }
        public bool Save()
        {
            if (SaveMode == GlobalVar._SaveMode.New)
                return _PersonRepository.AddNewPerson(Person, Address) > 0;//
            else
                return Update(Person, Address);
        }
        public bool Delete(int PersonID)
        {
            return _PersonRepository.DeletePerson(PersonID);
        }

        public clsPerson GetByID(int PersonID)
        {
            return _PersonRepository.GetPersonByID(PersonID);
        }

        public clsPerson GetByNationalNumber(string NationalNumber)
        {
            return _PersonRepository.GetPersonByNationalNumber(NationalNumber);
        }

        public List<clsPerson> GetList()
        {
            return _PersonRepository.GetPersonList();
        }


        public Dictionary<string, int> RelationshipStatusArabic()
        {
            Dictionary<string, int> Relations = new Dictionary<string, int>
            {
              {"اعزب",((int)enRelationshipStatus.Single)},
              {"متزوج",((int)enRelationshipStatus.Married)},
              {"مطلق",((int)enRelationshipStatus.Divorced) },
              {"يتيم",((int)enRelationshipStatus.Orphan) }
            };
            return Relations;
        }
        public bool IsNationalNumberUnique(string NationalNumber, int PersonID = -1)
        {
            return _PersonRepository.IsNationalNumberUnique(NationalNumber, PersonID);
        }
        public List<clsPersonTableView> GetPersonTableView(clsPersonFilter Filter)
        {
            return _PersonRepository.GetPersonTableView(Filter);
        }

    }
}
