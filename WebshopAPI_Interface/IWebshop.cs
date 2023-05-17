using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebshopAPI_Interface.DTO;

namespace WebshopAPI_Interface
{
    public interface IWebshop
    {
        public WebshopDTO GetWebshop(int WebshopId);
        public List<int> GetWebshopCategoryIds(int WebshopId);
    }
}
