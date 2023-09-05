using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using SportsZoneWebAPI.Models;

namespace SportsZoneWebAPI.Repositories
{
    public class PaymentRepository
    {
        private readonly SportsZoneDbContext _sportsZoneDbContext;
        public PaymentRepository(SportsZoneDbContext sportsZoneDbContext)
        {
            _sportsZoneDbContext = sportsZoneDbContext;
        }

        public async Task<IEnumerable<Payment>> GetAllPaymentMethods()
        {
            try
            {
                return await _sportsZoneDbContext.Payments.ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<Payment> GetPaymentMethodByPaymentID(int paymentID)
        {
            try
            {
                return await _sportsZoneDbContext.Payments.FindAsync(paymentID);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task AddNewPaymentMethod(Payment payment)
        {
            try
            {
                _sportsZoneDbContext.Payments.Add(payment);
                await _sportsZoneDbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task UpdatePayment(Payment payment)
        {
            try
            {
                _sportsZoneDbContext.Payments.Update(payment);
                await _sportsZoneDbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task DeletePaymentMethodByPaymentID(int paymentID)
        {
            try
            {
                Payment payment = await _sportsZoneDbContext.Payments.SingleOrDefaultAsync(payment => payment.PaymentID == paymentID);

                if (payment != null)
                {
                    _sportsZoneDbContext.Payments.Remove(payment);
                    await _sportsZoneDbContext.SaveChangesAsync();
                }
                else
                {
                    throw new KeyNotFoundException("Payment mode not found");
                } 
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task DeleteAllPaymentMethods()
        {
            try
            {
                IEnumerable<Payment> payments = await GetAllPaymentMethods();

                foreach (Payment payment in payments)
                {
                    _sportsZoneDbContext.Payments.Remove(payment);
                }
                await _sportsZoneDbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
