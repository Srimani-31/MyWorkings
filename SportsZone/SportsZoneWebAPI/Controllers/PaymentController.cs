using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using SportsZoneWebAPI.Repositories;
using SportsZoneWebAPI.Models;
using SportsZoneWebAPI.DTOs;

namespace SportsZoneWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly PaymentRepository _paymentRepository;
        public PaymentController(PaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }
        [HttpGet, Route("GetAllPaymentMethods")]
        public async Task<ActionResult<IEnumerable<Payment>>> GetAllPaymentMethods()
        {
            try
            {
                IEnumerable<Payment> payments = await _paymentRepository.GetAllPaymentMethods();
                return Ok(payments);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet, Route("GetPaymentMethod/{paymentID}")]
        public async Task<ActionResult<Payment>> GetPaymentMethodByPaymentID(int paymentID)
        {
            try
            {
                Payment payment = await _paymentRepository.GetPaymentMethodByPaymentID(paymentID);
                return Ok(payment);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost, Route("AddNewPaymentMethod")]
        public async Task<ActionResult<Payment>> AddNewPaymentMethod([FromBody] Payment payment)
        {
            try
            {
                await _paymentRepository.AddNewPaymentMethod(payment);
                return Ok(payment);
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException);
            }
        }

        [HttpPut, Route("UpdatePayment")]
        public async Task<ActionResult<Payment>> UpdatePayment([FromBody] Payment payment)
        {
            try
            {
                await _paymentRepository.UpdatePayment(payment);
                return Ok(payment);
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException);
            }
        }

        [HttpDelete, Route("DeletePayment/{paymentID}")]
        public async Task<ActionResult> DeletePaymentByPaymentID(int paymentID)
        {
            try
            {
                await _paymentRepository.DeletePaymentMethodByPaymentID(paymentID);
                return Ok($"Payment method with ID : {paymentID} deleted succesfully");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
