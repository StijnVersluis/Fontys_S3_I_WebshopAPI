using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebshopAPI_Interface.DTO
{
    public class CompanyDTO
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
    }
}
