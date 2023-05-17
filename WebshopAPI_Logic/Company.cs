using WebshopAPI_Interface;
using WebshopAPI_Interface.DTO;

namespace WebshopAPI_Logic
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? UserName { get; set; }
        public string? Description { get; set; }
        public int? CompanyID { get; set; }
        public int? KvkNr { get; set; }
        public int? ReferenceNr { get; set; }
        public string? Email { get; set; }
        public string? OrderEmail { get; set; }
        public string? logoPath { get; set; }
        public string? Password { get; set; }
        public bool Admin { get; set; }
        public List<int>? Webshops { get; set; }

        public string GetCompanyApiKeyByUserName(ICompany iCompany)
        {
            return iCompany.GetCompanyApiKeyByUserName(this.UserName);
        }

        public List<int> GetCompanyWebshops(ICompany iCompany)
        {
            return iCompany.GetCompanyWebshops(this.Id);
        }
    }
}
