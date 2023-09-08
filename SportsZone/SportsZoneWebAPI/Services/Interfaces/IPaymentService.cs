using SportsZoneWebAPI.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SportsZoneWebAPI.Services.Interfaces
{
    public interface IPaymentService
    {
        public Task<IEnumerable<PaymentResponseDTO>> GetAllPaymentMethods();
        public Task<PaymentResponseDTO> GetPaymentMethodByPaymentID(int paymentID);
        public Task AddNewPaymentMethod(PaymentRequestDTO paymentRequestDTO);
        public Task UpdatePayment(PaymentRequestDTO paymentRequestDTO);
        public Task DeletePaymentByPaymentID(int paymentID);
    }
}
