using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace SportsZoneWebAPI.Repositories.Interfaces
{
    public interface IUtil
    {
        public Task<bool> IsAvail<TEntity>(DbSet<TEntity> dbSet,string stringID = null, int intID = 0) where TEntity : class;
        public decimal CalculateTotalAmountByQuantity(int productID, int quantity);
        public decimal EvaluateCartTotal(int cartID);
        public string GenerateOrderID();
    }
}
