using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WEBCRAFT.MobileStore.Models;


namespace WEBCRAFT.MobileStore.DAL
{
   public  interface IProductRepository:IRepository<Product>
    {
          IEnumerable<Product> GetBestSeller();
    }
}
