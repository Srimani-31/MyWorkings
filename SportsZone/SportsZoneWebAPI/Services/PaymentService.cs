using AutoMapper;
using SportsZoneWebAPI.DTOs;
using SportsZoneWebAPI.Models;
using SportsZoneWebAPI.Repositories.Interfaces;
using SportsZoneWebAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SportsZoneWebAPI.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IMapper _mapper;
        public PaymentService(IPaymentRepository paymentRepository, IMapper mapper)
        {
            _paymentRepository = paymentRepository;
            _mapper = mapper;
        }
        public async Task<bool> IsAvail(int paymentID)
        {
            try
            {
                return await _paymentRepository.IsAvail(paymentID);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<IEnumerable<PaymentResponseDTO>> GetAllPaymentMethods()
        {
            try
            {
                IEnumerable<Payment> payments = await _paymentRepository.GetAllPaymentMethods();
                IList<PaymentResponseDTO> paymentResponseDTOs = new List<PaymentResponseDTO>();
                foreach (Payment payment in payments)
                {
                    PaymentResponseDTO paymentResponseDTO = _mapper.Map<PaymentResponseDTO>(payment);
                    paymentResponseDTOs.Add(paymentResponseDTO);
                }
                return paymentResponseDTOs;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<PaymentResponseDTO> GetPaymentMethodByPaymentID(int paymentID)
        {
            try
            {
                Payment payment = await _paymentRepository.GetPaymentMethodByPaymentID(paymentID);
                PaymentResponseDTO paymentResponseDTO = _mapper.Map<PaymentResponseDTO>(payment);

                return paymentResponseDTO;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task AddNewPaymentMethod(PaymentRequestDTO paymentRequestDTO)
        {
            try
            {
                Payment payment = _mapper.Map<Payment>(paymentRequestDTO);
                payment.CreatedBy = paymentRequestDTO.CreatedUpdatedBy;
                payment.CreatedDate = DateTime.Now;

                await _paymentRepository.AddNewPaymentMethod(payment);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task UpdatePayment(PaymentRequestDTO paymentRequestDTO)
        {
            try
            {
                Payment payment = await _paymentRepository.GetPaymentMethodByPaymentID(paymentRequestDTO.PaymentID);
                _mapper.Map(paymentRequestDTO, payment);

                await _paymentRepository.UpdatePayment(payment);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task DeletePaymentByPaymentID(int paymentID)
        {
            try
            {
                await _paymentRepository.DeletePaymentMethodByPaymentID(paymentID);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
