using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Unity;
using Data.Model;
using Data.Repository;
using BL.Manager.Interface;
using BE;
using Data.Repository.Interface;
namespace BL.Manager
{
    public class CompanyManager : ICompanyManager
    {
        private ICompanyRepository companyRepository;
        public CompanyManager(ICompanyRepository comp)
        {
            companyRepository = comp;
        }
        public bool Delete(int id)
        {
            return companyRepository.DeleteCompany(id);
        }

        public bool EditCompany(Company company)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Company, tblCompany>());
            IMapper mapper = config.CreateMapper();
            tblCompany comp = mapper.Map<Company, tblCompany>(company);
            return companyRepository.EditCompany(comp);
        }

        public bool EmployeeLogin(string email, string password)
        {
            return companyRepository.EmployeeLogin(email, password);
        }

        public IList<Company> GetCompanies()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<tblCompany, Company>());
            IMapper mapper = config.CreateMapper();
            var comp = companyRepository.GetCompanies().ToList();
            List<Company> Companylist = comp.Select(x => mapper.Map<tblCompany, Company>(x)).ToList();
            return Companylist;
        }

        public tblCompany GetCompany(int id)
        {
            return companyRepository.GetCompany(id);
        }

        public bool IsEmployeeVerify(string email, string password)
        {
            return companyRepository.IsEmailVerify(email, password);
        }

        public bool IsOTPVerify(string email, string password)
        {
            return companyRepository.IsOTPVerify(email, password);
        }

        public bool Login(string Username, string Password)
        {
            return companyRepository.Login(Username, Password);
        }

        public bool Register(Company company)
        {
            bool IsAvailable = false;

            var Company = GetCompanies().ToList();
            foreach (var item in Company)
            {
                if (item.CompanyName.ToLower() == company.CompanyName.ToLower())
                {
                    if (item.Email == company.Email)
                    {
                        IsAvailable = true;
                        break;
                    }
                }
            }
            if (IsAvailable == false)
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<Company, tblCompany>());
                IMapper mapper = config.CreateMapper();
                tblCompany comp = mapper.Map<Company, tblCompany>(company);
                return companyRepository.AddCompany(comp);
            }
            else
            {
                return false;
            }
           
        }
    }
}
