using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Advensco.EventManagement.Models;

namespace Advensco.EventManagement.Bll
{
    public class WarehouseBll : BaseBll
    {
        public WarehouseBll(UnitOfWork uow) : base(uow)
        {
        }

        internal int UpdateStockItems(List<WarehouseItem> stockItems)
        {
            foreach (var stockItem in stockItems)
            {
                var existngStock = UOW.WarehouseItems.Get(i => stockItem.ItemId == i.ItemId && stockItem.WarehouseId == i.WarehouseId).FirstOrDefault();
                if (existngStock != null)
                {
                    existngStock.Stock += stockItem.Stock;
                    UOW.WarehouseItems.Update(existngStock);
                }
                else
                {
                    UOW.WarehouseItems.Add(stockItem);
                }
            }
            UOW.Complete();
            return 0;
        }
    }
}