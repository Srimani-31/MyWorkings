using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsZoneWebAPI.Repositories.Interfaces
{
    public interface IUtil
    {
        public decimal CalculateTotalAmountByQuantity(int productID, int quantity);
        public decimal EvaluateCartTotal(int cartID);
        public string GenerateOrderID();
    }
}
