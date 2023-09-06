//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//using SportsZoneWebAPI.Repositories;
//using SportsZoneWebAPI.Models;
//using SportsZoneWebAPI.DTOs;

//namespace SportsZoneWebAPI.Services
//{
//    public class PaymentService 
//    {
//        private readonly PaymentRepository _paymentRepository;
//        public PaymentService(PaymentRepository paymentRepository)
//        {
//            _paymentRepository = paymentRepository;
//        }
//        public async Task<IEnumerable<Payment>> GetAllPaymentMethods()
//        {
//            try
//            {
//                IEnumerable<Payment> payments = await _paymentRepository.GetAllPaymentMethods();
//                return payments;
//            }
//            catch (Exception)
//            {
//                throw;
//            }
//        }
//        public async Task<Payment> GetPaymentMethodByPaymentID(int paymentID)
//        {
//            try
//            {
//                Payment payment = await _paymentRepository.GetPaymentMethodByPaymentID(paymentID);
//                return payment;
//            }
//            catch (Exception)
//            {
//                throw;
//            }
//        }

//        public async Task AddNewPaymentMethod(Payment payment)
//        {
//            try
//            {
//                await _paymentRepository.AddNewPaymentMethod(payment);
//            }
//            catch (Exception)
//            {
//                throw;
//            }
//        }

//        public async Task UpdatePayment(Payment payment)
//        {
//            try
//            {
//                await _paymentRepository.UpdatePayment(payment);
//            }
//            catch (Exception)
//            {
//                throw;
//            }
//        }

//        public async Task DeletePaymentByPaymentID(int paymentID)
//        {
//            try
//            {
//                await _paymentRepository.DeletePaymentMethodByPaymentID(paymentID);
//            }
//            catch (Exception)
//            {
//                throw;
//            }
//        }
//    }
//}
