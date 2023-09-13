using SportsZoneWebAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace SportsZoneWebAPI.Repositories.Interfaces
{
    public interface IPaymentRepository
    {
        public Task<bool> IsAvail(int paymentID);
        public Task<IEnumerable<Payment>> GetAllPaymentMethods();
        public Task<Payment> GetPaymentMethodByPaymentID(int paymentID);
        public Task AddNewPaymentMethod(Payment payment);
        public Task UpdatePayment(Payment payment);
        public Task DeletePaymentMethodByPaymentID(int paymentID);
        public Task DeleteAllPaymentMethods();
    }
}
