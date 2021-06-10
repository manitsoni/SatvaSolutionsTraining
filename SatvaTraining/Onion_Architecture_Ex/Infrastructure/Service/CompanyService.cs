using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Core.Service;
using Core.ViewModel;
using Core.Model;
using Core.Interface;

namespace Infrastructure.Service
{
    public class CompanyService : ICompanyService
    {
        ICompanyRepository repository;
        public CompanyService(ICompanyRepository repo)
        {
            repository = repo;
        }
        public bool AddCompany(CompanyViewModel company)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<CompanyViewModel, tblCompany>());
            IMapper mapper = config.CreateMapper();
            tblCompany c = mapper.Map<CompanyViewModel, tblCompany>(company);
            return repository.AddCompany(c);
        }

        public bool DeleteCompany(int id)
        {
            return repository.DeleteCompany(id);
        }

        public IList<CompanyViewModel> GetCompanies()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<CompanyList_Result, CompanyViewModel>());
            IMapper mapper = config.CreateMapper();
            var data = repository.GetCompanies().ToList();
            List<CompanyViewModel> companyData = data.Select(x => mapper.Map<CompanyList_Result, CompanyViewModel>(x)).ToList();
            return companyData;
        }

        public IList<CompanyViewModel> GetCompanyById(int id)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<GetCompany_Result, CompanyViewModel>());
            IMapper mapper = config.CreateMapper();
            var Data = repository.GetCompanyById(id);
            IList<CompanyViewModel> cVm = Data.Select(x => mapper.Map<GetCompany_Result, CompanyViewModel>(x)).ToList();
            return cVm;
        }

        public bool UpdateCompany(CompanyViewModel company)
        {
            var Config = new MapperConfiguration(cfg => cfg.CreateMap<CompanyViewModel, tblCompany>());
            IMapper mapper = Config.CreateMapper();
            tblCompany c = mapper.Map<CompanyViewModel, tblCompany>(company);
            return repository.UpdateCompany(c);
        }
    }
}
