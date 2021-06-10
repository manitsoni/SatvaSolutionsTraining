using RepositoryDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryDemo.Repository
{
    public interface ICompanyRepository
    {
        IEnumerable<tblCompany> GetCompanies();
        bool Add(tblCompany obj);
        bool Update(tblCompany obj);
        bool Delete(int id);
        tblCompany GetCompanyById(int id);
    }
}
