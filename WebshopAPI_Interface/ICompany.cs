using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WebshopAPI_Interface.DTO;

namespace WebshopAPI_Interface
{
    public interface ICompany
    {
        public List<int> GetCompanyWebshops(int CompanyId);
        public string GetCompanyApiKeyByUserName(string CompanyUserName);
    }
}
