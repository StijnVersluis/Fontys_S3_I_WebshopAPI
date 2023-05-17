using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebshopAPI_Interface.DTO;

namespace WebshopAPI_Interface
{
    public interface ICategory
    {
        public CategoryDTO GetCategory(int CategoryId);
    }
}
